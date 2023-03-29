using Microsoft.Web.WebView2.Wpf;

namespace CinemaPlus.ViewModels.MovieViewModels
{
    public class MovieTrailerUCViewModel : BaseViewModel
    {
        public WebView2 Web { get; set; } = new WebView2();
        public void Navigate(string video)
        {
            Web.NavigateToString(video);
        }
    }
}
