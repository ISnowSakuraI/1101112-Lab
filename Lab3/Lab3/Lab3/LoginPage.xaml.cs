using System;
using Xamarin.Forms;

namespace Lab3
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnGoToProductPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage());
        }
    }
}
