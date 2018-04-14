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



namespace Storage_Management_System
{
    
    public sealed partial class MenuPage : Page
    {
        // menu page let customer enter the functionality page
        public MenuPage()
        {
            this.InitializeComponent();
        }

        private void menu_goods(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GoodsPage));
        }

        private void menu_order(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OrderPage));
        }

        private void menu_update(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Up_Login_Page));
        }

        private void menu_out(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
