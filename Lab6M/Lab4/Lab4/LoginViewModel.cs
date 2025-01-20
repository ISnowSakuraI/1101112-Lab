using System.ComponentModel;
using Xamarin.Forms;
using Lab4.APIs;
using System.Threading.Tasks;
using Lab4.Models;
using Xamarin.Essentials;
using System;

namespace Lab4
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Login Login { get; set; } = new Login();

        private string _displayText;
        public string DisplayText
        {
            get => _displayText;
            set
            {
                _displayText = value;
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public Command LoginCommand { get; set; }
        public Command ClearCommand { get; set; }

        private readonly ApiService _apiService;

        public LoginViewModel()
        {
            _apiService = new ApiService();

            LoginCommand = new Command(async () => await LoginUser());
            ClearCommand = new Command(() =>
            {
                Login.Email = string.Empty;
                Login.Password = string.Empty;
                DisplayText = string.Empty;
                OnPropertyChanged(nameof(Login));
            });
        }

        private async Task LoginUser()
        {
            try
            {
                var success = await _apiService.Login(Login);
                if (success)
                {
                    // ล็อกอินสำเร็จ
                    DisplayText = "Login successful!";
                    await Application.Current.MainPage.Navigation.PushAsync(new ProductPage());
                }
                else
                {
                    // ล็อกอินล้มเหลว
                    DisplayText = "Login failed!";
                    Login.Email = string.Empty;
                    Login.Password = string.Empty;
                    OnPropertyChanged(nameof(Login));
                }
            }
            catch (Exception ex)
            {
                // แสดงข้อผิดพลาดให้ผู้ใช้เห็น
                DisplayText = $"Login failed: {ex.Message}";
                Login.Email = string.Empty;
                Login.Password = string.Empty;
                OnPropertyChanged(nameof(Login));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}