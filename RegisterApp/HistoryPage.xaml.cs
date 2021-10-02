using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RegisterApp
{
    public partial class HistoryPage : ContentPage
    {
        List<Product> purchased_products = new List<Product>();
        public HistoryPage(List<Product> pro)
        {
            InitializeComponent();
            purchased_products = pro;

            //Binding
            BindingContext = this;
            proList.ItemsSource = purchased_products;
        }

        void myList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new PurchasedHistory((e.SelectedItem as Product)));
        }
    }
}
