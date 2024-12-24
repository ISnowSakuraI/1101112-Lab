using System;
using System.Collections.Generic;
using System.ComponentModel;
using Lab3.Models;
using Lab3.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}