using System;
using System.ComponentModel;

namespace RegisterApp
{
    public class Product : INotifyPropertyChanged
    {
        public string _productQuantity;
        public string productQuantity
        {
            get { return _productQuantity; }
            set
            {
                if (_productQuantity != value)
                {
                    _productQuantity = value;
                    OnPropertyChanged("productQuantity");
                }
            }
        }

        public double _productPrice;
        public double productPrice
        {
            
                get { return _productPrice; }
                set { 
                      if (_productPrice != value)
                    {
                        _productPrice = value;
                        OnPropertyChanged("productPrice");
                    }
                }
        }

        private string _productName;
        public string productName
        {
            get { return _productName; }
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged("productName");
                }
            }
        }

        private string _purchasedTime;
        public string purchasedTime
        {
            get { return _purchasedTime; }
            set
            {
                if (_purchasedTime != value)
                {
                    _purchasedTime = value;
                    OnPropertyChanged("purchasedTime");
                }
            }
        }
        private string _totalBought;
        public string totalBought
        {
            get { return _totalBought; }
            set
            {
                if (_totalBought != value)
                {
                    _totalBought = value;
                    OnPropertyChanged("totalBought");
                }
            }
        }
        public Product() {
            productName = "";
            productQuantity = "";
            productPrice = 0.0;
            totalBought = "";
            purchasedTime = "";
        }
        public Product(string name, string qty, double price, string total, string p_Time)
        {
            productName = name;
            productQuantity = qty;
            productPrice = price;
            totalBought = total;
            purchasedTime = p_Time;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            
        }
        
    }
}
