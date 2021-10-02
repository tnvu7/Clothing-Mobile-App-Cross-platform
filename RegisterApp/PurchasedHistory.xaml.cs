using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RegisterApp
{
    public partial class PurchasedHistory : ContentPage
    {
        Product currP;
        public PurchasedHistory(Product product)
        {
            InitializeComponent();
            currP = product;
            Console.WriteLine(currP.productName + ", " + currP.purchasedTime + ", " + currP.totalBought);

            //Binding
            BindingContext = currP;
        }
    }
}
