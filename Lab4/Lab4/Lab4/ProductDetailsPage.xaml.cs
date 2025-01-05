using Xamarin.Forms;

namespace Lab4
{
    public partial class ProductDetailsPage : ContentPage
    {
        private readonly ProductListViewModel _viewModel;

        public ProductDetailsPage(Product selectedProduct, ProductListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = selectedProduct; // ผูกข้อมูลสินค้าที่เลือก
            _viewModel = viewModel; // กำหนด ViewModel
        }

        // Event handler for the BACK button
        private async void OnBackButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync(); // กลับไปยังหน้าก่อนหน้า (ProductPage)
        }

        // Event handler for the ADD button
        private void OnAddToCartClicked(object sender, System.EventArgs e)
        {
            if (BindingContext is Product selectedProduct)
            {
                _viewModel.AddToCart(selectedProduct); // เพิ่มสินค้าลงในตะกร้า
                DisplayAlert("Added to Cart", "Product has been added to your cart.", "OK");
            }
        }
    }
}