using System.Windows.Input;
using Xamarin.Forms;
using Lab4.APIs;
using System.ComponentModel;
using Lab4.Models;
using Xamarin.Essentials;
using System.Net.Http;

namespace Lab4
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Register Register { get; set; }
        ApiService apiService;
        public Command BackCommand { get; }
        public Command RegisterCommand { get; }

        public RegisterViewModel()
        {
            apiService = new ApiService();
            Register = new Register();

            BackCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            RegisterCommand = new Command(async () =>
            {
                if (!ValidatePassword())
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "OK");
                    return;
                }

                var response = await apiService.Register(Register);
                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Register", "Register successfully!!!", "OK");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    await Application.Current.MainPage.DisplayAlert("Register", $"Fail: {errorMessage}", "OK");
                }
            });
        }

        private bool ValidatePassword()
        {
            return Register.Password == Register.ConfirmPassword;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}