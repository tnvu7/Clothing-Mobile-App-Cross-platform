using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace RegisterApp
{
    public partial class AddNewProductPage : ContentPage
    {
        ObservableCollection<Product> m_products;
        Product currP = new Product();

        public AddNewProductPage(ObservableCollection<Product> pro)
        {
            InitializeComponent();
            m_products = pro;
        }

        void SaveItem(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrEmpty(EntryPrice.Text) || string.IsNullOrEmpty(EntryQuantity.Text))
            {
                DisplayAlert("Error", "Please fill out all the fields", "OK");
            }
            else
            {
                currP.productName = EntryName.Text;
                currP.productPrice = Double.Parse(EntryPrice.Text);
                currP.productQuantity = EntryQuantity.Text;
                m_products.Add(new Product(currP.productName, currP.productQuantity, currP.productPrice, "", ""));

                currP.productName = "";
                currP.productPrice = 0.0;
                currP.productQuantity = "";
                DisplayAlert("Done!", "New Product Added successfully", "OK");
                Navigation.PopAsync();
            }
        }

        void Cancel(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
