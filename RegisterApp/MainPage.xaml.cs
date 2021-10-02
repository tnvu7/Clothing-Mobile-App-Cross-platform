using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RegisterApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Product> products;

        private bool qtyBtnPressed = false;
        private bool hasQty = true;
        public int RowHeight { get; set; }
        Product currentprd = new Product();
        List<Product> purchased_products = new List<Product>();

        public MainPage(ObservableCollection<Product> app_products, List<Product> proArr)
        {
            InitializeComponent();
            products = app_products;
            purchased_products = proArr;

            //Initializing            
            typeLabel.Text = "Type";
            qtyLabel.Text = "Quantity";
            totalLabel.Text = "Total";

            //Binding
            BindingContext = this;
            myList.ItemsSource = products;
        }
        void calculateTotal(string name)
        {
            foreach (Product p in products)
            {
                if (p.productName == name)
                {
                    currentprd.productPrice = p.productPrice;
                    if (Int32.Parse(p.productQuantity) < Int32.Parse(currentprd.productQuantity))
                        hasQty = false;
                    else
                        hasQty = true;
                    break;
                }
            }

            double totalP = currentprd.productPrice * Int32.Parse(currentprd.productQuantity);
            totalLabel.Text = $"{totalP}";
        }

        void myList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            typeLabel.Text = (e.SelectedItem as Product).productName;
            currentprd.productName = typeLabel.Text;

            if (currentprd.productQuantity != "")
            {
                calculateTotal(currentprd.productName);
            }
        }

        void Btn_clicked(System.Object sender, System.EventArgs e)
        {
            if (qtyBtnPressed == false)
            {
                qtyBtnPressed = true;
                qtyLabel.Text = "";
            }
            qtyLabel.Text += (sender as Button).Text;
                        
            currentprd.productQuantity = qtyLabel.Text;
            
            if (currentprd.productName != "")
            {
                calculateTotal(currentprd.productName);
            }
        }

        void BuyBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (qtyLabel.Text == "Quantity" || typeLabel.Text == "Type")
            {
                DisplayAlert("Error", "Please select a product and enter the quantity", "OK");
            }
            else
            {
                if (hasQty == false)
                {
                    DisplayAlert("ERROR", "The amount you entered is insufficient", "OK");
                }
                else
                {

                    foreach (Product p in products)
                    {
                        if (p.productName == currentprd.productName)
                        {
                            p.productQuantity = $"{Int32.Parse(p.productQuantity) - Int32.Parse(currentprd.productQuantity)}";
                            purchased_products.Add(new Product(p.productName, currentprd.productQuantity, p.productPrice, totalLabel.Text, $"{DateTime.Now}"));
                            break;

                        }
                    }

                }

                //Initialize Product obj, bool, Labels
                currentprd.productName = "";
                currentprd.productPrice = 0.0;
                currentprd.productQuantity = "";
                qtyBtnPressed = false;
                hasQty = true;
                typeLabel.Text = "Type";
                qtyLabel.Text = "Quantity";
                totalLabel.Text = "Total";
            }
            
        }

        void ManagerBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ManagerPanel(products, purchased_products));
        }
    }
}
