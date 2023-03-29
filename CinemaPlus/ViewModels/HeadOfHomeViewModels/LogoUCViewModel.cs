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
        public RelayCommand LogoCommand { get; set; }
        public RelayCommand AdminSideCommand { get; set; }
        public AdminSignInUC AdminSignInView { get; set; } = new AdminSignInUC();
        public AdminSignInUCViewModel AdminSignInViewModel { get; set; } = new AdminSignInUCViewModel();


        private string logoImage;

        public string LogoImage
        {
            get { return logoImage; }
            set { logoImage = value; OnPropertyChanged(); }
        }

        private Cursor cursor;

        public Cursor Cursor
        {
            get { return cursor; }
            set { cursor = value; OnPropertyChanged(); }
        }


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
            cursor = Cursors.Hand;
            LogoImage = @"\Images\cinemaKhanLogo.png";
            LogoCommand = new RelayCommand((w) =>
            {
                if (!App.IsInAdminSide)
                {
                    if (App.PageWrapPanel.Children.Count != 0)
                    {
                        App.PageWrapPanel.Children.RemoveAt(0);
                        App.PageWrapPanel.Children.Add(App.PreviousPages[0]);
                        App.PreviousPages.RemoveRange(1, App.PreviousPages.Count - 1);
                        var homePageView = App.PageWrapPanel.Children[0] as HomePageUC;
                        var homePageViewModel = homePageView.DataContext as HomePageUCViewModel;
                        homePageViewModel.TodayView.TodayUCScroll.ScrollToTop();
                        if (App.HomePageViewModel.TodayIsChecked)
                        {
                        }
                        else if (App.HomePageViewModel.ScheduleIsChecked)
                        {
                        }
                        App.Web.Source = new Uri($"https://www.youtube.com");
                    }
                    App.IsInAdminSide = false;
                    App.SideChangedCommands();
                }
            });
        }
    }
}
