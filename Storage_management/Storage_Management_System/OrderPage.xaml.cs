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
using Windows.UI.Popups;

namespace Storage_Management_System
{

    public sealed partial class OrderPage : Page
    {



        private MobileServiceCollection<OrderInfo, OrderInfo> items;
        IMobileServiceTable<OrderInfo> toTable = App.client.GetTable<OrderInfo>();
        


        public OrderPage()
        {
            this.InitializeComponent();
            gettable();
        }


     

        private void Show_table(object sender, RoutedEventArgs e)
        {
            gettable();
        }


        private void Update_data(object sender, RoutedEventArgs e)
        {
            update();
            gettable();

        }

      

        private  void Delete_Click(object sender, RoutedEventArgs e)
        {
            delete();
            gettable();
        }







        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }







        async void gettable()
        {
            MobileServiceInvalidOperationException exep = null;


            try
            {

                items = await toTable.ToCollectionAsync();


            }
            catch (MobileServiceInvalidOperationException ex)
            {
                exep = ex;
            }



            if (exep == null) MylistView.DataContext = items;

        }

        async void update()
        {
            MobileServiceInvalidOperationException exep = null;
            string info = intype.Text;


            OrderInfo iteme = new OrderInfo
            {
                Id = info,
                OrderGoods = "order has finish",
                address = "order has deliver",
                status = true,

            };
            try
            {
                await toTable.UpdateAsync(iteme);
                items = await toTable.ToCollectionAsync();

            }
            catch (MobileServiceInvalidOperationException ex)
            {
                exep = ex;
            }
        }

        async void delete()
        {
           
   
               
            string info = intype.Text;
            OrderInfo dele = new OrderInfo
            {

                Id = info
            };
          //  if (info == or.Id)
        //    {
                await toTable.DeleteAsync(dele);
                items = await toTable.ToCollectionAsync();
        //    }
       //     else
        //    {
        //        string msg = "$ ID is not correct ";
          //      await new MessageDialog(msg).ShowAsync();
         //   }
        }
    }
}
