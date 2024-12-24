using System;
using Xamarin.Forms;

namespace Lab1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
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
    }
}