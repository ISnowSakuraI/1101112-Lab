using Lab5.Views;
using Xamarin.Forms;

namespace Lab5
{
    public partial class MainPage : NavigationPage
    {
        public MainPage() : base(new RegistrationPage())
        {
            InitializeComponent();
        }
    }
}