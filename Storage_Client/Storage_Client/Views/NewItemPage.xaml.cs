using System;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace Storage_Client
{
    public partial class NewItemPage : ContentPage
    {

        public static MobileServiceClient MobileService =
            new MobileServiceClient(
    "https://ordertable.azurewebsites.net"
);

       
        public OrderInfo OrderInfo { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            OrderInfo = new OrderInfo();
           

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {


            string text1 = ordergoodsinput.Text;

            string text2 = addressinput.Text;

            string text3 = phonenumberinput.Text;
            CurrentPlatform.Init();
            OrderInfo item = new OrderInfo
            {
                OrderGoods = text1,

                address = text2,
              
                phonenumber = text3
            };
            await MobileService.GetTable<OrderInfo>().InsertAsync(item);
            // MessagingCenter.Send(this, "AddItem", Item);
            // await Navigation.PopToRootAsync();
        }
    }
}
