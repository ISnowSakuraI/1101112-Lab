using System;
using System.Collections.ObjectModel;
using Lab4.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Lab4.APIs;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Lab4
{
    class ProductListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product> Products
        {
            get => myproducts;
            set
            {
                myproducts = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private ObservableCollection<Product> myproducts;
        public ObservableCollection<Product> CartItems { get; set; }

        private readonly ApiService apiService;
        public Command LogoutCommand { get; set; }

        public ProductListViewModel()
        {
            CartItems = new ObservableCollection<Product>();
            apiService = new ApiService();

            GetProduct();

            // Command สำหรับ Logout
            LogoutCommand = new Command(() => Logout());
        }

        async void GetProduct()
        {
            Products = await apiService.GetProducts();
        }

        private void Logout()
        {
            // ตั้งหน้า MainPage กลับไปเป็นหน้า LoginPage
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
