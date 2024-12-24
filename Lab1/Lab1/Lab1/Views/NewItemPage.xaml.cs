using System;
using System.Collections.Generic;
using System.ComponentModel;
using Lab1.Models;
using Lab1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab1.Views
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