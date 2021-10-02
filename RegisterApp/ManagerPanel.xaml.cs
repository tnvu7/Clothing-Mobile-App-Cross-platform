using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace RegisterApp
{
    public partial class ManagerPanel : ContentPage
    {
        ObservableCollection<Product> m_products;
        List<Product> purchased_products = new List<Product>();

        public ManagerPanel(ObservableCollection<Product> products, List<Product> pro)
        {
            InitializeComponent();
            m_products = products;
            purchased_products = pro;
        }

        void History_Page(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HistoryPage(purchased_products));
        }

        void Restock_Page(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RestockPage(m_products));
        }

        void NewProduct_Page(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddNewProductPage(m_products));
        }
    }
}
