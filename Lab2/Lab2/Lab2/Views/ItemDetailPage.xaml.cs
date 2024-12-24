using System.ComponentModel;
using Lab2.ViewModels;
using Xamarin.Forms;

namespace Lab2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}