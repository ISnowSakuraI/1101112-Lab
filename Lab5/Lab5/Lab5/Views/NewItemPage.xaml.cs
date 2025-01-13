using System;
using System.Collections.Generic;
using System.ComponentModel;
using Lab5.Models;
using Lab5.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab5.Views
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