using Xamarin.Essentials;
using Xamarin.Forms;

namespace Lab4
{
    public partial class ProductPage : TabbedPage
    {
        private readonly ProductListViewModel _viewModel;

        public ProductPage()
        {
            InitializeComponent();

            // ตรวจสอบ Token ก่อนแสดงหน้า ProductPage
            var accessToken = Preferences.Get("accesstoken", "");
            if (string.IsNullOrEmpty(accessToken))
            {
                // หากไม่มี Token ให้นำทางกลับไปยังหน้า Login
                Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            _viewModel = new ProductListViewModel();
            BindingContext = _viewModel;
        }
    }
}