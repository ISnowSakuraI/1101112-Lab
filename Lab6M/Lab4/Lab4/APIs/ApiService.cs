using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lab4.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Lab4.APIs
{
    class ApiService
    {
        private readonly HttpClient client;
        private readonly string BaseUrl = "http://10.0.2.2:49396";
        private readonly string RegisterUrl = "http://10.0.2.2:53681";
        private readonly string TokenUrl = "http://10.0.2.2:53681";
        private readonly string LogoutUrl = "http://10.0.2.2:53681";

        public ApiService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ObservableCollection<Product>> GetProducts()
        {
            try
            {
                var response = await client.GetAsync($"{BaseUrl}/api/products");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<ObservableCollection<Product>>(content);
                    return items;
                }
                else
                {
                    // Handle non-success status codes
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error: {response.StatusCode}, {errorContent}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                Console.WriteLine($"Error in GetProducts: {ex.Message}");
                throw;
            }
        }

        public async Task<HttpResponseMessage> Register(Register item)
        {
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{RegisterUrl}/api/Account/Register", content);
                return response;
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                Console.WriteLine($"Error in Register: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> Login(Login login)
        {
            try
            {
                var dict = new Dictionary<string, string>
        {
            { "Content-Type", "application/x-www-form-urlencoded" },
            { "grant_type", "password" },
            { "username", login.Email },
            { "password", login.Password }
        };

                var response = await client.PostAsync($"{TokenUrl}/token", new FormUrlEncodedContent(dict));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonConvert.DeserializeObject<User>(content);

                    // บันทึก Token ลงใน Preferences
                    Preferences.Set("accesstoken", tokenResponse.accesstoken);
                    Preferences.Set("token_type", tokenResponse.token_type);
                    Preferences.Set("username", tokenResponse.userName);

                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Login failed: {errorContent}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Login: {ex.Message}");
                throw;
            }
        }
        public async Task<string> Logout()
        {
            try
            {
                // อ่าน Token จาก Preferences
                var accessToken = Preferences.Get("accesstoken", "");
                if (string.IsNullOrEmpty(accessToken))
                {
                    return "No access token found. Please login again.";
                }

                // ตั้งค่า Header Authorization
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                // ส่งคำขอล็อกเอาท์
                var response = await client.PostAsync($"{LogoutUrl}/api/Account/Logout", null);

                // ตรวจสอบผลลัพธ์
                if (response.IsSuccessStatusCode)
                {
                    // ล้างข้อมูลการเข้าสู่ระบบ
                    ClearUserPreferences();
                    return null; // ไม่มีข้อผิดพลาด
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return errorContent;
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private void ClearUserPreferences()
        {
            Preferences.Remove("accesstoken");
            Preferences.Remove("token_type");
            Preferences.Remove("username");
        }

    }
}