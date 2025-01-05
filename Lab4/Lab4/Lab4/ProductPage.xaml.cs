using System.Linq;
using Xamarin.Forms;

namespace Lab4
{
    public partial class ProductPage : TabbedPage
    {
        private readonly ProductListViewModel _viewModel;

        public ProductPage()
        {
            InitializeComponent();
            _viewModel = new ProductListViewModel();
            BindingContext = _viewModel; // กำหนด BindingContext
        }

        // Event handler when a product is selected
        private async void OnProductSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Product selectedProduct)
            {
                // นำทางไปยังหน้า ProductDetailsPage และส่งข้อมูลสินค้าที่เลือก
                await Navigation.PushAsync(new ProductDetailsPage(selectedProduct, _viewModel));
            }

            // ล้างการเลือกสินค้า
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}