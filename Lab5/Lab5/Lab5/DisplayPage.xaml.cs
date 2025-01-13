using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Lab5.Models;
using Lab5.Services;

namespace Lab5.Views
{
    public partial class DisplayPage : ContentPage
    {
        private List<User> _users;
        private Database _database;

        public DisplayPage(List<User> users)
        {
            InitializeComponent();

            // ตั้งค่า Database
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
            _database = new Database(dbPath);

            _users = users;

            if (_users != null && _users.Count > 0)
            {
                // แสดงข้อมูลผู้ใช้ทั้งหมด
                DisplayUsers(_users);
            }
            else
            {
                // แสดงข้อความเมื่อไม่มีข้อมูล
                DisplayNoDataMessage();
            }

            // รับข้อมูลผู้ใช้ที่อัปเดตจากหน้า EditPage
            MessagingCenter.Subscribe<EditPage, User>(this, "UpdateUser", (sender, updatedUser) =>
            {
                // อัปเดตข้อมูลผู้ใช้ในรายการ
                var index = _users.FindIndex(u => u.Id == updatedUser.Id);
                if (index != -1)
                {
                    _users[index] = updatedUser;
                    DisplayUsers(_users); // อัปเดต UI ด้วยข้อมูลใหม่
                }
            });
        }

        private void DisplayUsers(List<User> users)
        {
            // ล้างข้อมูลเก่า
            UserDataContainer.Children.Clear();

            foreach (var user in users)
            {
                // สร้าง Frame สำหรับแต่ละผู้ใช้
                var frame = new Frame
                {
                    BackgroundColor = Color.LightBlue,
                    CornerRadius = 10,
                    Padding = 10
                };

                var stackLayout = new StackLayout { Spacing = 5 };

                // เพิ่มข้อมูลผู้ใช้ใน Frame
                stackLayout.Children.Add(new Label { Text = $"ID: {user.UserId}", TextColor = Color.Red, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
                stackLayout.Children.Add(new Label { Text = $"Name: {user.FirstName} {user.LastName}", TextColor = Color.Blue, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
                stackLayout.Children.Add(new Label { Text = $"Date of Birth: {user.DateOfBirth:dd/MM/yyyy hh:mm:ss tt}", TextColor = Color.Red, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
                stackLayout.Children.Add(new Label { Text = $"Email: {user.Email}", TextColor = Color.Red, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
                stackLayout.Children.Add(new Label { Text = $"Password: {user.Password}", TextColor = Color.Red, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
                stackLayout.Children.Add(new Label { Text = $"Address: {user.Address}", TextColor = Color.Red, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });

                // เพิ่ม TapGestureRecognizer ให้กับ Frame
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (sender, e) => OnDataTapped(user);
                frame.GestureRecognizers.Add(tapGestureRecognizer);

                frame.Content = stackLayout;
                UserDataContainer.Children.Add(frame);
            }
        }

        private void DisplayNoDataMessage()
        {
            // แสดงข้อความเมื่อไม่มีข้อมูล
            UserDataContainer.Children.Clear();
            UserDataContainer.Children.Add(new Label
            {
                Text = "No data available",
                TextColor = Color.Black,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            });
        }

        private async void OnDataTapped(User user)
        {
            if (user != null)
            {
                // แสดงแจ้งเตือน "Do you want to edit data?"
                bool editAnswer = await DisplayAlert("Do you want to edit data?", $"ID: {user.UserId}\nName: {user.FirstName} {user.LastName}", "YES", "NO");

                if (editAnswer)
                {
                    // นำทางไปยังหน้า EditPage และส่งข้อมูลผู้ใช้ไปด้วย
                    await Navigation.PushAsync(new EditPage(user));
                }
                else
                {
                    // ถ้าผู้ใช้กด "NO" ในแจ้งเตือนแรก ให้ถามต่อว่า "Do you want to delete this data?"
                    bool deleteAnswer = await DisplayAlert("Delete Data", $"Do you want to delete this data?\nID: {user.UserId}\nName: {user.FirstName} {user.LastName}", "YES", "NO");

                    if (deleteAnswer)
                    {
                        // ลบข้อมูลผู้ใช้จากฐานข้อมูล
                        await _database.DeleteUserAsync(user);
                        await DisplayAlert("Success", "User deleted successfully", "OK");

                        // อัปเดต UI โดยลบผู้ใช้ออกจากรายการ
                        _users.Remove(user);
                        DisplayUsers(_users);
                    }
                }
            }
            else
            {
                await DisplayAlert("Info", "No data to edit or delete", "OK");
            }
        }
    }
}