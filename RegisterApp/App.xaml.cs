using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegisterApp
{
    public partial class App : Application
    {
        public ObservableCollection<Product> products = new ObservableCollection<Product>
        {
            new Product("Pants", "20", 50.7, "", ""),
            new Product("Shoes", "50", 90, "",""),
            new Product("Hats", "10", 20.7, "",""),
            new Product("Tshirts", "10", 10, "",""),
            new Product("Dresses", "24", 40.3, "","")
        };
        List<Product> purchased_products = new List<Product>();
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(products, purchased_products));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
