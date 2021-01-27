using TermTracker.Views;
using Xamarin.Forms;

namespace TermTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TermsPage())
            {
                BarBackgroundColor = Color.FromHex("#002F51")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
