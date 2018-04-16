using System;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace Storage_Client
{
    public partial class NewItemPage : ContentPage
    {
        //connecting the Azure server
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

            // catch the value inputed
            string text1 = ordergoodsinput.Text;

            string text2 = addressinput.Text;

            string text3 = phonenumberinput.Text;

            string quan = quantityinput.Text;

            bool text4 = false;
           

            // init the Azure function
            CurrentPlatform.Init();
            OrderInfo item = new OrderInfo
            {
                OrderGoods = text1,

                address = text2,
              
                phonenumber = text3,

                quantity = quan,

                 status = text4
            };
            await MobileService.GetTable<OrderInfo>().InsertAsync(item);


            await Navigation.PushAsync(new MainPage());
            // MessagingCenter.Send(this, "AddItem", Item);
            // await Navigation.PopToRootAsync();
        }
    }
}
