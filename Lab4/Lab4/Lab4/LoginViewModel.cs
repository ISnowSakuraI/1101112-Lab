using System.ComponentModel;
using Xamarin.Forms;

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

        public LoginViewModel()
        {
            LoginCommand = new Command(() =>
            {
                DisplayText = $"Username: {Login.Email} Password: {Login.Password}";
            });

            ClearCommand = new Command(() =>
            {
                Login.Email = string.Empty;
                Login.Password = string.Empty;
                DisplayText = string.Empty;
                OnPropertyChanged(nameof(Login));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
