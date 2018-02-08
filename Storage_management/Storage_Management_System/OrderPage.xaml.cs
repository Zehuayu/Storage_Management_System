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
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Storage_Management_System.Database;



namespace Storage_Management_System
{
    
    public sealed partial class OrderPage : Page
    {



        private MobileServiceCollection<OrderInfo, OrderInfo> items;



        public OrderPage()
        {
            this.InitializeComponent();
        }


        private async void Add_Button(object sender, RoutedEventArgs e)
        {

            OrderInfo item = new OrderInfo
            {

                OrderGoods = "Fire Rice",

                address = "Dublin Road",

                phonenumber = 087475255
               
            };

            await App.MobileService.GetTable<OrderInfo>().InsertAsync(item);


        }

        private async void show_table(object sender, RoutedEventArgs e)
        {
            MobileServiceInvalidOperationException exep = null;


            try
            {

                items = await App.MobileService.GetTable<OrderInfo>().ToCollectionAsync();


            }
            catch (MobileServiceInvalidOperationException ex)
            {
                exep = ex;
            }



            if (exep == null) MylistView.DataContext = items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }
    }
}
