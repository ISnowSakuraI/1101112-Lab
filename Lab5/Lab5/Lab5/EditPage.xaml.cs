using System;
using System.IO;
using Xamarin.Forms;
using Lab5.Models;
using Lab5.Services;

namespace Lab5.Views
{
    public partial class EditPage : ContentPage
    {
        private Database _database;
        private User _user;

        public EditPage(User user)
        {
            InitializeComponent();
            _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3"));
            _user = user;

            // แสดงข้อมูลผู้ใช้ในหน้า Edit
            IdEntry.Text = _user.UserId;
            FirstNameEntry.Text = _user.FirstName;
            LastNameEntry.Text = _user.LastName;
            EmailEntry.Text = _user.Email;
            PasswordEntry.Text = _user.Password;
            ConfirmPasswordEntry.Text = _user.Password;
            DateOfBirthPicker.Date = _user.DateOfBirth;
            AddressEntry.Text = _user.Address;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
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
                await DisplayAlert("Error", "Please fill in all fields", "OK");
                return;
            }

            // ตรวจสอบรหัสผ่าน
            if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
            {
                await DisplayAlert("Error", "Passwords do not match", "OK");
                return;
            }

            // อัปเดตข้อมูลผู้ใช้
            _user.UserId = IdEntry.Text;
            _user.FirstName = FirstNameEntry.Text;
            _user.LastName = LastNameEntry.Text;
            _user.Email = EmailEntry.Text;
            _user.Password = PasswordEntry.Text;
            _user.DateOfBirth = DateOfBirthPicker.Date;
            _user.Address = AddressEntry.Text;

            // บันทึกข้อมูลลงฐานข้อมูล
            await _database.SaveUserAsync(_user);
            await DisplayAlert("Success", "User updated successfully", "OK");

            // ส่งข้อมูลผู้ใช้ที่อัปเดตแล้วกลับไปยังหน้า DisplayPage
            MessagingCenter.Send(this, "UpdateUser", _user);

            // กลับไปหน้า DisplayPage
            await Navigation.PopAsync();
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            // ล้างข้อมูลในฟิลด์
            IdEntry.Text = string.Empty;
            FirstNameEntry.Text = string.Empty;
            LastNameEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            PasswordEntry.Text = string.Empty;
            ConfirmPasswordEntry.Text = string.Empty;
            AddressEntry.Text = string.Empty;
        }
    }
}