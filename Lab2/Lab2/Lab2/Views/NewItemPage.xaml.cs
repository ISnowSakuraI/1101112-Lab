using System;
using System.Collections.Generic;
using System.ComponentModel;
using Lab2.Models;
using Lab2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab2.Views
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