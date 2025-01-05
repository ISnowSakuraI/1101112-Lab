using Xamarin.Forms;

namespace Lab4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Wrap MainPage in NavigationPage
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
