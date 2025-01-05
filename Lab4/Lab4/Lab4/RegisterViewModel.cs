using System.Windows.Input;
using Xamarin.Forms;

namespace Lab4
{
    public class RegisterViewModel : BindableObject
    {
        private string email;
        private string password;
        private string confirmPassword;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand => new Command(() =>
        {
            // Perform registration logic
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                Application.Current.MainPage.DisplayAlert("Error", "All fields are required.", "OK");
                return;
            }

            if (Password != ConfirmPassword)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            Application.Current.MainPage.DisplayAlert("Success", "Registration successful!", "OK");
        });

        public ICommand CancelCommand => new Command(() =>
        {
            // Clear the fields
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        });
    }
}
