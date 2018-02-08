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
            string amount = AmountInput.Text;
            string price = PriceInput.Text;
            string supplier = SupplierInput.Text;


            using (var conn = DatabaseConnection.GetDbConnectionone())
            {
                var addInfo = new GoodsInfo() { Name = name, Amount = amount, Price = price, Supplier = supplier  };
                var count = conn.Insert(addInfo);
            }

            this.Frame.Navigate(typeof(StorageAddPage));
            
        }
    }
}
