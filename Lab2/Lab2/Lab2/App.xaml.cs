using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Lab2
{
    public partial class App : Application
    {
        private List<string> colors = new List<string>(); // List to store color names

        public App()
        {
            InitializeComponent();

            // Initialize list with colors
            colors.Add("FFFFFF");
            colors.Add("FFFF00");
            colors.Add("FF00FF");
            colors.Add("00FFFF");
            colors.Add("FFF000");
            colors.Add("000FFF");

            // Set the items source for ListView
            lstview.ItemsSource = colors;
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            // Get references to controls in the current page context
            var entryX = (Entry)((ContentPage)MainPage).FindByName("EntryX");
            var entryY = (Entry)((ContentPage)MainPage).FindByName("EntryY");
            var entryName = (Entry)((ContentPage)MainPage).FindByName("EntryName");
            var resultLabel = (Label)((ContentPage)MainPage).FindByName("ResultLabel");
            var radioMale = (RadioButton)((ContentPage)MainPage).FindByName("RadioMale");
            var radioFemale = (RadioButton)((ContentPage)MainPage).FindByName("RadioFemale");

            // Read values and perform calculation
            if (int.TryParse(entryX.Text, out int x) && int.TryParse(entryY.Text, out int y))
            {
                string name = entryName.Text;
                int result = x * y;
                string gender = radioMale.IsChecked ? "Male" : radioFemale.IsChecked ? "Female" : "Not Specified";

                // Display result
                resultLabel.Text = $"{name}\n{result}\n{gender}";
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please enter valid numeric values for X and Y.", "OK");
            }
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            // Reset values
            var entryX = (Entry)((ContentPage)MainPage).FindByName("EntryX");
            var entryY = (Entry)((ContentPage)MainPage).FindByName("EntryY");
            var entryName = (Entry)((ContentPage)MainPage).FindByName("EntryName");
            var resultLabel = (Label)((ContentPage)MainPage).FindByName("ResultLabel");
            var radioMale = (RadioButton)((ContentPage)MainPage).FindByName("RadioMale");
            var radioFemale = (RadioButton)((ContentPage)MainPage).FindByName("RadioFemale");

            // Clear all fields
            entryX.Text = string.Empty;
            entryY.Text = string.Empty;
            entryName.Text = string.Empty;
            resultLabel.Text = "X * Y = ?";
            radioMale.IsChecked = false;
            radioFemale.IsChecked = false;
        }

        private void OnGoClicked(object sender, EventArgs e)
        {
            // Get reference to the Editor and WebView controls
            var editorUrl = (Editor)((ContentPage)((TabbedPage)MainPage).CurrentPage).FindByName("EditorUrl");
            var webView = (WebView)((ContentPage)((TabbedPage)MainPage).CurrentPage).FindByName("WebView");

            string url = editorUrl.Text;

            // Load the URL into the WebView
            if (!string.IsNullOrEmpty(url))
            {
                // Ensure the URL starts with "http://" or "https://"
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }
                webView.Source = url;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid URL.", "OK");
            }
        }

        // Method to add color to the ListView
        public void AddList_Clicked(object sender, EventArgs e)
        {
            colors.Add("AAAAAA");  // Add a new color
            lstview.ItemsSource = null; // Clear the listview's data
            lstview.ItemsSource = colors; // Rebind the data source to update ListView
        }

        // Method to delete the selected color from the ListView
        public void DelList_Clicked(object sender, EventArgs e)
        {
            var selectedColor = lstview.SelectedItem as string;  // Get the selected color
            if (selectedColor != null)
            {
                colors.Remove(selectedColor);  // Remove selected color from list
                lstview.ItemsSource = null; // Clear the listview's data
                lstview.ItemsSource = colors; // Rebind the data source to update ListView
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please select an item to delete.", "OK");
            }
        }

        private void lst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedColor = e.SelectedItem as string;  // Get selected color
            Application.Current.MainPage.DisplayAlert("Item Selected", selectedColor, "OK");
        }
    }
}
