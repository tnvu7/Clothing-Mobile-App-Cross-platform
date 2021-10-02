using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace RegisterApp
{
    public partial class RestockPage : ContentPage
    {
        ObservableCollection<Product> m_products;
        String chosenP = "";
        public RestockPage(ObservableCollection<Product> products)
        {
            InitializeComponent();
            m_products = products;

            //Binding
            BindingContext = this;
            restockList.ItemsSource = m_products;
        }

        void Restock_Item(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(newQty.Text) && !string.IsNullOrEmpty(chosenP))
            {
                foreach (Product p in m_products)
                {
                    if (p.productName == chosenP)
                    {
                        int original = Int32.Parse(p.productQuantity);
                        int add = Int32.Parse(newQty.Text);
                        int final = original + add;
                        p.productQuantity = final.ToString();
                        chosenP = "";
                        newQty.Text = "";
                        break;
                    }
                }
            }
            else if (string.IsNullOrEmpty(newQty.Text))
            {
                DisplayAlert("Error", "You have to provide a new quantity", "OK");
                //chosenP = "";
                newQty.Text = "";
            } else if (string.IsNullOrEmpty(chosenP))
            {
                DisplayAlert("Error", "You have to select a new item", "OK");
                chosenP = "";
            }
        }

        void Cancel(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        void myList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            chosenP = (e.SelectedItem as Product).productName;
        }
    }
}
