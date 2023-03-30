using CinemaPlus.Commands;
using CinemaPlus.Helpers;
using CinemaPlus.ViewModels.AdminSideViewModels;
using CinemaPlus.ViewModels.HomePageViewModels;
using CinemaPlus.Views.UserControls.AdminSide;
using CinemaPlus.Views.UserControls.HomePage;
using System;
using System.Windows.Input;

namespace CinemaPlus.ViewModels
{
    public class LogoUCViewModel : BaseViewModel
    {
        public RelayCommand AdminSideCommand { get; set; }

        public AdminSignInUC AdminSignInView { get; set; } = new AdminSignInUC();
        public AdminSignInUCViewModel AdminSignInViewModel { get; set; } = new AdminSignInUCViewModel();

        public RelayCommand HomeCommand { get; set; }
        public LogoUCViewModel()
        {
            AdminSignInViewModel.UsernameWarningTB = AdminSignInView.UsernameWarningTB;
            AdminSignInViewModel.PasswordWarningTB = AdminSignInView.PasswordWarningTB;
            AdminSignInViewModel.PasswordBox = AdminSignInView.PasswordBox;


            AdminSideCommand = new RelayCommand((a) =>
            {
                AdminSignInView.DataContext = AdminSignInViewModel;
                App.PageWrapPanel.Children.Clear();
                App.PageWrapPanel.Children.Add(Helper.RemoveElementFromItsParent(AdminSignInView));
            });

            HomeCommand = new RelayCommand((h) =>
            {
                if (App.PreviousPages.Count != 0)
                {
                    App.PageWrapPanel.Children.RemoveAt(0);
                    App.PageWrapPanel.Children.Add(App.PreviousPages[0]);
                    App.PreviousPages.RemoveRange(1, App.PreviousPages.Count - 1);
                    //App.MoviesWrapPanel.Children.Add(Helper.RemoveElementFromItsParent(App.EndingView));
                    var homePageView = App.PageWrapPanel.Children[0] as HomePageUC;
                    var homePageViewModel = homePageView.DataContext as HomePageUCViewModel;
                    homePageViewModel.TodayView.TodayUCScroll.ScrollToTop();
                    //homePageViewModel.TodayViewModel.FilterMovies();
                    homePageViewModel.TodayCommand.Execute(null);
                    App.Web.Source = new Uri($"https://www.youtube.com");
                }
                App.IsInAdminSide = false;
                App.SideChangedCommands();
            });
        }
    }
}
