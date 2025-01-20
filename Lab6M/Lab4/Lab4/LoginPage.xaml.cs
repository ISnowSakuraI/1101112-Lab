using System;
using Xamarin.Forms;

namespace Lab4
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnGoToRegisterPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void OnGoToProductPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage());
        }
    }
}