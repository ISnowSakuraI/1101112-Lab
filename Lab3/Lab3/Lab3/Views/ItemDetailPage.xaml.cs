using System.ComponentModel;
using Lab3.ViewModels;
using Xamarin.Forms;

namespace Lab3.Views
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