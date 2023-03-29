using CinemaPlus;
using CinemaPlus.Commands;
using CinemaPlus.Helpers;
using CinemaPlus.ViewModels.AdminSideViewModels;
using CinemaPlus.ViewModels.EndingViewModels;
using CinemaPlus.ViewModels.HomePageViewModels;
using CinemaPlus.Views.UserControls.AdminSide;
using CinemaPlus.Views.UserControls.HomePage;
using System;

namespace CinemaPlus.ViewModels
{
    public class SecondToolsUCViewModel : BaseViewModel
    {
        public RelayCommand HomeCommand { get; set; }
        public RelayCommand CampaignCommand { get; set; }
        public RelayCommand TariffsCommand { get; set; }
        public RelayCommand CineBonusCommand { get; set; }
        public RelayCommand FaqCommand { get; set; }

        public RelayCommand AdminSideCommand { get; set; }
        public CineBonusUC CineBonusView { get; set; } = new CineBonusUC();
        public AdminSignInUC AdminSignInView { get; set; } = new AdminSignInUC();
        public AdminSignInUCViewModel AdminSignInViewModel { get; set; } = new AdminSignInUCViewModel();
        public SecondToolsUCViewModel()
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
                    var homePageView = App.PageWrapPanel.Children[0] as HomePageUC;
                    var homePageViewModel = homePageView.DataContext as HomePageUCViewModel;
                    homePageViewModel.TodayView.TodayUCScroll.ScrollToTop();
                    homePageViewModel.TodayCommand.Execute(null);
                    App.Web.Source = new Uri($"https://www.youtube.com");
                }
                App.IsInAdminSide = false;
                App.SideChangedCommands();
            });

            TariffsCommand = new RelayCommand((t) => 
            {
                App.PageWrapPanel.Children.Clear();
                App.Web.Source = new Uri($"https://www.youtube.com");
                App.IsInAdminSide = false;
                App.SideChangedCommands();
            });

            FaqCommand = new RelayCommand((f) =>
            {
                App.PageWrapPanel.Children.Clear();
                App.Web.Source = new Uri($"https://www.youtube.com");
                App.IsInAdminSide = false;
                App.SideChangedCommands();
            });
        }
    }
}

