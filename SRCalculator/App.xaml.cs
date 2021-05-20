using SRCalculator.Services;
using SRCalculator.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SRCalculator
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            //DataStore.Deserialize();
        }

        protected override void OnSleep()
        {
            //DataStore.Serialize();
        }

        protected override void OnResume()
        {
        }
    }
}
