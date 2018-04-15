using SQLite.Net;
using Storage_Management_System.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;




namespace Storage_Management_System
{
   
    public sealed partial class StorageAddPage : Page
    {

        public StorageAddPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (var conn = DatabaseConnection.GetDbConnectionone())
            {
                conn.CreateTable<GoodsInfo>();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GoodsPage));
        }

       

        private void SAP_Add(object sender, RoutedEventArgs e)
        {
            string name = NameInput.Text;
            int amount = Convert.ToInt32(AmountInput.Text);
            double price = Convert.ToDouble(PriceInput.Text);
            double outprice = price * 1.3 / amount;
            string supplier = SupplierInput.Text;
            DateTime time = DateTime.Now;


            using (var conn = DatabaseConnection.GetDbConnectionone())
            {
                var addInfo = new GoodsInfo() { Name = name, Amount = amount, Price = price / amount,Outprice = outprice ,Supplier = supplier, Time = time  };
                var count = conn.Insert(addInfo);
            }

            this.Frame.Navigate(typeof(StorageAddPage));
            
        }
    }
}
