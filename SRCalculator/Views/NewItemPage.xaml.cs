using SRCalculator.Models;
using SRCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SRCalculator.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            SaveSum.Text = NewItemViewModel.sum.ToString();
            BindingContext = new NewItemViewModel();

        }
    }
}