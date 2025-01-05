using Xamarin.Forms;

namespace Lab4
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }

        // Event handler for the BACK button
        private async void OnBackButtonClicked(object sender, System.EventArgs e)
        {
            // Navigate back to the LoginPage
            await Navigation.PopAsync();
        }
    }
}