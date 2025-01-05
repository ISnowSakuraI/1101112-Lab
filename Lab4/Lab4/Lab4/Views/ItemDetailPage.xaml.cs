using System.ComponentModel;
using Lab4.ViewModels;
using Xamarin.Forms;

namespace Lab4.Views
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