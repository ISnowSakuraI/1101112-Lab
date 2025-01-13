using System;
using System.IO;
using Xamarin.Forms;
using Lab5.Models;
using Lab5.Services;

namespace Lab5.Views
{
    public partial class RegistrationPage : ContentPage
    {
        private Database _database;

        public RegistrationPage()
        {
            InitializeComponent();
            // ตั้งค่า SQLite Database
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
            _database = new Database(dbPath); // สร้างอ็อบเจกต์ Database
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            // ตรวจสอบว่ากรอกข้อมูลครบหรือไม่
            if (string.IsNullOrWhiteSpace(IdEntry.Text) ||
                string.IsNullOrWhiteSpace(FirstNameEntry.Text) ||
                string.IsNullOrWhiteSpace(LastNameEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                string.IsNullOrWhiteSpace(PasswordEntry.Text) ||
                string.IsNullOrWhiteSpace(ConfirmPasswordEntry.Text) ||
                string.IsNullOrWhiteSpace(AddressEntry.Text))
            {
                await DisplayAlert("Required", "Not complete !!!", "OK");
                return;
            }

            // ตรวจสอบรหัสผ่าน
            if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
            {
                await DisplayAlert("Error", "Passwords do not match", "OK");
                return;
            }

            // สร้าง User ใหม่
            var user = new User
            {
                UserId = IdEntry.Text,
                FirstName = FirstNameEntry.Text,
                LastName = LastNameEntry.Text,
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text,
                DateOfBirth = DateOfBirthPicker.Date,
                Address = AddressEntry.Text
            };

            // บันทึกลงฐานข้อมูล SQLite
            await _database.SaveUserAsync(user);

            await DisplayAlert("Registration", "Thanks for Registration", "OK");

            // ล้างข้อมูลในฟอร์ม
            IdEntry.Text = string.Empty;
            FirstNameEntry.Text = string.Empty;
            LastNameEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            PasswordEntry.Text = string.Empty;
            ConfirmPasswordEntry.Text = string.Empty;
            AddressEntry.Text = string.Empty;
        }

        private async void OnShowClicked(object sender, EventArgs e)
        {
            // ดึงข้อมูลผู้ใช้ทั้งหมดจากฐานข้อมูล
            var users = await _database.GetUsersAsync();

            // นำทางไปยังหน้า DisplayPage และส่งข้อมูลผู้ใช้ไปด้วย
            await Navigation.PushAsync(new DisplayPage(users));
        }
    }
}