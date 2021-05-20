using SRCalculator.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SRCalculator.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            
            BindingContext = new ItemDetailViewModel();
        }
    }
}