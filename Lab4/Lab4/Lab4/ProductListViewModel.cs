using System;
using System.Collections.ObjectModel;
using Lab4.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab4
{
    public class ProductListViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> CartItems { get; set; }

        public ProductListViewModel()
        {
            LoadData();
            CartItems = new ObservableCollection<Product>(); // กำหนดค่าเริ่มต้นให้ CartItems
        }

        private void LoadData()
        {
            Products = new ObservableCollection<Product>
            {
        new Product
        {
            Id = 1,
            Title = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
            Price = 109.95,
            Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
            Category = "men's clothing",
            Image = "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg",
            Rating = new Rating { Rate = 3.9, Count = 120 }
        },
        new Product
        {
            Id = 2,
            Title = "Mens Casual Premium Slim Fit T-Shirts",
            Price = 22.3,
            Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.",
            Category = "men's clothing",
            Image = "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg",
            Rating = new Rating { Rate = 4.1, Count = 259 }
        },
        new Product
        {
            Id = 3,
            Title = "Mens Cotton Jacket",
            Price = 55.99,
            Description = "great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors. Good gift choice for you or your family member. A warm hearted love to Father, husband or son in this thanksgiving or Christmas Day.",
            Category = "men's clothing",
            Image = "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg",
            Rating = new Rating { Rate = 4.7, Count = 500 }
        },
        new Product
        {
            Id = 4,
            Title = "Mens Casual Slim Fit",
            Price = 15.99,
            Description = "The color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description.",
            Category = "men's clothing",
            Image = "https://fakestoreapi.com/img/71YXzeOuslL._AC_UY879_.jpg",
            Rating = new Rating { Rate = 2.1, Count = 430 }
        },
        new Product
        {
            Id = 5,
            Title = "John Hardy Women's Legends Naga Gold & Silver Dragon Station Chain Bracelet",
            Price = 695,
            Description = "From our Legends Collection, the Naga was inspired by the mythical water dragon that protects the ocean's pearl. Wear facing inward to be bestowed with love and abundance, or outward for protection.",
            Category = "jewelery",
            Image = "https://fakestoreapi.com/img/71pWzhdJNwL._AC_UL640_QL65_ML3_.jpg",
            Rating = new Rating { Rate = 4.6, Count = 400 }
        },
        new Product
        {
            Id = 6,
            Title = "Solid Gold Petite Micropave",
            Price = 168,
            Description = "Satisfaction Guaranteed. Return or exchange any order within 30 days.Designed and sold by Hafeez Center in the United States. Satisfaction Guaranteed. Return or exchange any order within 30 days.",
            Category = "jewelery",
            Image = "https://fakestoreapi.com/img/61sbMiUnoGL._AC_UL640_QL65_ML3_.jpg",
            Rating = new Rating { Rate = 3.9, Count = 70 }
        },
        new Product
        {
            Id = 7,
            Title = "White Gold Plated Princess",
            Price = 9.99,
            Description = "Classic Created Wedding Engagement Solitaire Diamond Promise Ring for Her. Gifts to spoil your love more for Engagement, Wedding, Anniversary, Valentine's Day...",
            Category = "jewelery",
            Image = "https://fakestoreapi.com/img/71YAIFU48IL._AC_UL640_QL65_ML3_.jpg",
            Rating = new Rating { Rate = 3, Count = 400 }
        },
        new Product
        {
            Id = 8,
            Title = "Pierced Owl Rose Gold Plated Stainless Steel Double",
            Price = 10.99,
            Description = "Rose Gold Plated Double Flared Tunnel Plug Earrings. Made of 316L Stainless Steel",
            Category = "jewelery",
            Image = "https://fakestoreapi.com/img/51UDEzMJVpL._AC_UL640_QL65_ML3_.jpg",
            Rating = new Rating { Rate = 1.9, Count = 100 }
        },
        new Product
        {
            Id = 9,
            Title = "WD 2TB Elements Portable External Hard Drive - USB 3.0",
            Price = 64,
            Description = "USB 3.0 and USB 2.0 Compatibility Fast data transfers Improve PC Performance High Capacity; Compatibility Formatted NTFS for Windows 10, Windows 8.1, Windows 7; Reformatting may be required for other operating systems; Compatibility may vary depending on user’s hardware configuration and operating system",
            Category = "electronics",
            Image = "https://fakestoreapi.com/img/61IBBVJvSDL._AC_SY879_.jpg",
            Rating = new Rating { Rate = 3.3, Count = 203 }
        },
        new Product
        {
            Id = 10,
            Title = "SanDisk SSD PLUS 1TB Internal SSD - SATA III 6 Gb/s",
            Price = 109,
            Description = "Easy upgrade for faster boot up, shutdown, application load and response (As compared to 5400 RPM SATA 2.5” hard drive; Based on published specifications and internal benchmarking tests using PCMark vantage scores) Boosts burst write performance, making it ideal for typical PC workloads The perfect balance of performance and reliability Read/write speeds of up to 535MB/s/450MB/s (Based on internal testing; Performance may vary depending upon drive capacity, host device, OS and application.)",
            Category = "electronics",
            Image = "https://fakestoreapi.com/img/61U7T1koQqL._AC_SX679_.jpg",
            Rating = new Rating { Rate = 2.9, Count = 470 }
        },
        new Product
        {
            Id = 11,
            Title = "Silicon Power 256GB SSD 3D NAND A55 SLC Cache Performance Boost SATA III 2.5",
            Price = 109,
            Description = "3D NAND flash are applied to deliver high transfer speeds Remarkable transfer speeds that enable faster bootup and improved overall system performance. The advanced SLC Cache Technology allows performance boost and longer lifespan 7mm slim design suitable for Ultrabooks and Ultra-slim notebooks. Supports TRIM command, Garbage Collection technology, RAID, and ECC (Error Checking & Correction) to provide the optimized performance and enhanced reliability.",
            Category = "electronics",
            Image = "https://fakestoreapi.com/img/71kWymZ+c+L._AC_SX679_.jpg",
            Rating = new Rating { Rate = 4.8, Count = 319 }
        },
        new Product
        {
            Id = 12,
            Title = "WD 4TB Gaming Drive Works with Playstation 4 Portable External Hard Drive",
            Price = 114,
            Description = "Expand your PS4 gaming experience, Play anywhere Fast and easy, setup Sleek design with high capacity, 3-year manufacturer's limited warranty",
            Category = "electronics",
            Image = "https://fakestoreapi.com/img/61mtL65D4cL._AC_SX679_.jpg",
            Rating = new Rating { Rate = 4.8, Count = 400 }
        },
        new Product
        {
            Id = 13,
            Title = "Acer SB220Q bi 21.5 inches Full HD (1920 x 1080) IPS Ultra-Thin",
            Price = 599,
            Description = "21. 5 inches Full HD (1920 x 1080) widescreen IPS display And Radeon free Sync technology. No compatibility for VESA Mount Refresh Rate: 75Hz - Using HDMI port Zero-frame design | ultra-thin | 4ms response time | IPS panel Aspect ratio - 16: 9. Color Supported - 16. 7 million colors. Brightness - 250 nit Tilt angle -5 degree to 15 degree. Horizontal viewing angle-178 degree. Vertical viewing angle-178 degree 75 hertz",
            Category = "electronics",
            Image = "https://fakestoreapi.com/img/81QpkIctqPL._AC_SX679_.jpg",
            Rating = new Rating { Rate = 2.9, Count = 250 }
        },
        new Product
        {
            Id = 14,
            Title = "Samsung 49-Inch CHG90 144Hz Curved Gaming Monitor (LC49HG90DMNXZA) – Super Ultrawide Screen QLED",
            Price = 999.99,
            Description = "49 INCH SUPER ULTRAWIDE CURVED GAMING MONITOR with QLED TECHNOLOGY - Quantum Dot technology enables deep blacks, bright whites, and stunning color for an immersive gaming experience. HDR Support, FreeSync Premium Pro, Ultra-wide curved screen with 32:9 aspect ratio, 144Hz refresh rate, 1ms response time, built-in speakers, USB hub, multiple inputs, and DisplayPort",
            Category = "electronics",
            Image = "https://fakestoreapi.com/img/81t2zFYPjqL._AC_SX679_.jpg",
            Rating = new Rating { Rate = 4.4, Count = 500 }
        },
        new Product
        {
            Id = 15,
            Title = "Apple iPhone 13 Pro Max, 128GB, Sierra Blue",
            Price = 1099,
            Description = "The iPhone 13 Pro Max has a 6.7-inch Super Retina XDR display, 128GB of storage, and is powered by the A15 Bionic chip. It offers 5G connectivity, improved camera capabilities, and is available in Sierra Blue color.",
            Category = "smartphones",
            Image = "https://fakestoreapi.com/img/81n_-xuNXTL._AC_SX679_.jpg",
            Rating = new Rating { Rate = 4.6, Count = 250 }
        },
        new Product
        {
            Id = 16,
            Title = "Samsung Galaxy S21 Ultra 5G",
            Price = 1199,
            Description = "Samsung Galaxy S21 Ultra 5G comes with a 6.8-inch Dynamic AMOLED display, Snapdragon 888 processor, 12GB of RAM, and 128GB of internal storage. It also supports 5G connectivity and has a quad-camera setup with a 108MP primary camera.",
            Category = "smartphones",
            Image = "https://fakestoreapi.com/img/91cB9pFHZtL._AC_SY679_.jpg",
            Rating = new Rating { Rate = 4.5, Count = 340 }
        },
        new Product
        {
            Id = 17,
            Title = "OnePlus 9 Pro 5G",
            Price = 969,
            Description = "OnePlus 9 Pro 5G is powered by Snapdragon 888 chipset, featuring a 6.7-inch Fluid AMOLED display, 12GB RAM, and 256GB storage. It comes with 5G connectivity, 120Hz refresh rate, and Hasselblad camera for professional-level photography.",
            Category = "smartphones",
            Image = "https://fakestoreapi.com/img/91zZP4_UyRL._AC_SY679_.jpg",
            Rating = new Rating { Rate = 4.2, Count = 550 }
        },
        new Product
        {
            Id = 18,
            Title = "Google Pixel 6 Pro",
            Price = 899,
            Description = "Google Pixel 6 Pro features a 6.7-inch LTPO OLED display, Google Tensor chip, 12GB of RAM, and 128GB storage. It has a 50MP main camera and 4K video recording. It also supports 5G and comes with a clean Android experience.",
            Category = "smartphones",
            Image = "https://fakestoreapi.com/img/71mHhGLRbXL._AC_SY679_.jpg",
            Rating = new Rating { Rate = 4.4, Count = 300 }
        },
        new Product
        {
            Id = 19,
            Title = "Xiaomi Mi 11 Ultra 5G",
            Price = 799,
            Description = "Xiaomi Mi 11 Ultra features a 6.81-inch AMOLED display, Snapdragon 888 processor, 12GB RAM, and 256GB storage. The camera setup includes a 50MP primary camera, 48MP ultra-wide camera, and a 48MP telephoto camera. It also has 5G connectivity.",
            Category = "smartphones",
            Image = "https://fakestoreapi.com/img/71zx6Klrs1L._AC_SY679_.jpg",
            Rating = new Rating { Rate = 4.2, Count = 200 }
        },
        new Product
        {
            Id = 20,
            Title = "Oppo Find X3 Pro 5G",
            Price = 1149,
            Description = "Oppo Find X3 Pro comes with a 6.7-inch AMOLED display, Snapdragon 888 chipset, 12GB of RAM, and 256GB storage. It also has a 50MP quad-camera setup and supports 5G connectivity.",
            Category = "smartphones",
            Image = "https://fakestoreapi.com/img/71xt2V-TO8L._AC_SY679_.jpg",
            Rating = new Rating { Rate = 4.3, Count = 210 }
        },
            };
        }

        // เพิ่มสินค้าลงในตะกร้า
        public void AddToCart(Product product)
        {
            CartItems.Add(product);
            OnPropertyChanged(nameof(CartItems));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
