using System.ComponentModel;
using Lab5.ViewModels;
using Xamarin.Forms;

namespace Lab5.Views
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