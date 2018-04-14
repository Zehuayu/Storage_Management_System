using Storage_Management_System.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Storage_Management_System
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (var conn = DatabaseConnection.GetDbConnection())
            {
                conn.CreateTable<LoginData>();
                var addPsd = new LoginData() { Password = "0000" };
                var count = conn.Insert(addPsd);

            }
        }

        private async void m_ok(object sender, RoutedEventArgs e)
        {
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
        }

        private void m_re(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Reference));
        }

    }
}
