using System;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace Storage_Client
{
    public partial class ItemOrder : ContentPage
    {
    //    public static MobileServiceClient MobileService =
    //new MobileServiceClient(
                //"https://ordertable.azurewebsites.net");
        public OrderInfo orderinfo { get; set; }

        public ItemOrder()
        {
            InitializeComponent();

            orderinfo = new OrderInfo
            {
                OrderGoods = "Item name",
                address = "This is an item description.",
                phonenumber = 1234567
            };

            BindingContext = this;
        }

        //async void Post_Clicked(object sender, EventArgs e)
        //{
        //    CurrentPlatform.Init();
        //    OrderInfo item = new OrderInfo() { OrderGoods = orderinfo.OrderGoods, address = orderinfo.address,
        //        phonenumber = orderinfo.phonenumber};
        //    await MobileService.GetTable<OrderInfo>().InsertAsync(item);
        //}
       
    }
}
