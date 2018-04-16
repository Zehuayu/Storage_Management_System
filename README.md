Storage_Management_System
=============================
 Zehua Yu - g00307279 
 
 
## Project Overview

My project is a kind of Order App, the clinet can post the order from client to the main proces. In the main process the user can manage the all details of goods. 

The main process is developed base on the UWP in the Visual Studio.

The Client process is deveoped base on the Xamarin Studio.


## The Introduction of UWP

Windows 10 introduces the Universal Windows Platform (UWP), which provides a common app platform on every device that runs Windows 10. The UWP provides a guaranteed core API across devices. New adaptive controls and layout panels help you to tailor your UI across a broad range of device screen resolutions and sizes, and respond to multiple kinds of device input. A unified app store makes your app available on Windows 10 devices such as PC, tablet, Xbox, HoloLens, Surface Hub, and Internet of Things (IoT) devices.

UWP is flexible. You can use languages such as C#, C++, Javascript, and VB. Have a C++ desktop app that you want to modernize with UWP features and sell in the Microsoft store? That's okay, too.

## The Introduction of Xamarin

Xamarin is a software company founded back in 2011. And it was recently in 2016 that it was acquired by Microsoft. Xamarin provides a developer with tools that can help them in building cross-platform mobile applications. The applications can have all the native features and also share the common codebase at the same time. As per Xamarin stats, more than 15000 companies rely on their tools and the list includes many big names out there.

Xamarin tools are available to download with Visual Studio and you can directly create Android, iOS and Windows apps from Visual Studio itself. Most of the common code is written in C#. So you don’t need to learn Java, Objective-C or Swift to build apps if you already know C#. If you are a beginner, then taking the Xamarin path instead of the conventional learning process can actually teach you app development for more than one platforms. 


## The introduction of process

Mainpage class: the class contain the main login functionality. 

firstly, get the password data from SQLite databases 

            using (var conn = DatabaseConnection.GetDbConnection())
            {
                var psd = conn.Table<LoginData>().Where(v => v.Id.Equals(1));
                foreach (var item in psd)
                {

                    if (passwordBox.Password == item.Password)
                    {
                        string msg = "$ successful login ";
                        await new MessageDialog(msg).ShowAsync();
                        this.Frame.Navigate(typeof(MenuPage));
                    }
                    else
                    {
                        string msg = "$ please type correct password! ";
                        await new MessageDialog(msg).ShowAsync();
                    }


                }

            }
            
Menupage class: this page only give the 4 button to enter different page for user.

Goodspage class: this page offer the management functionality. By connecting the databases, get and add the data to the databases.

on the another hand, the page using the Bind functionality to show the data on the page.


        public ObservableCollection<Recording> recordings = new ObservableCollection<Recording>();
        public ObservableCollection<Recording> Recordings { get { return this.recordings; } }

        public GoodsPage()
        {
            this.InitializeComponent();

            using (var conn = DatabaseConnection.GetDbConnectionone())
            {
                var query = conn.Table<GoodsInfo>();

                foreach (var iteam in query)
                {
                    this.recordings.Add(new Recording()
                    {

                        Id = iteam.Id,
                        Name = iteam.Name,
                        Amount = iteam.Amount,
                        Price = iteam.Price,
                        Outprice = iteam.Outprice,
                        Supplier = iteam.Supplier,
                        Time = iteam.Time
                        

                    });
                }
            }

        }
        
OrderPage class: this page is that receive the client data with some modifing functionality. By Bingding functionality, the cloud databases to show on the local page.

Azure Connecting code:
        
           public static MobileServiceClient client = new MobileServiceClient("https://ordertable.azurewebsites.net");
           
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
        
                await toTable.DeleteAsync(dele);
                items = await toTable.ToCollectionAsync();
      
        }


## Mobile App review

ItemDetailPage class: this is a page for the introduction of goods, the customer can look at details of goods.


    public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

ItemPage class: this class shows all of menu.

NewItemPage class: this class is order page, the user can use the functionality of page to post the order to azure service.

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


## Conclusion

This app contain two app, the main process is UWP app including the some management functionality. The mobile app contains the post and some sample functionality.















