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



namespace Storage_Management_System
{
  
    public sealed partial class Up_Login_Page : Page
    {
        public Up_Login_Page()
        {
            this.InitializeComponent();
        }






        private async void UP_OK(object sender, RoutedEventArgs e)
        {
            if (lo_password.Password == "" || lo_sure_password.Password == "")
            {
                string msg = $"the block can not be null!";
                await new MessageDialog(msg).ShowAsync();
            }
            else {




                using (var conn = DatabaseConnection.GetDbConnection())

                {
                var psd = conn.Table<LoginData>().Where(v => v.Id.Equals(1));

                    foreach (var item in psd)
                    {

                        if (lo_password_old.Password == item.Password)
                        {
                            if (lo_password.Password == lo_sure_password.Password)
                            {
                                conn.Execute("UPDATE LoginData SET Password = ? Where Id = ?", lo_sure_password.Password, 1);
                                this.Frame.Navigate(typeof(MenuPage));
                            }
                            else
                            {
                                string msg = "$ type the same new password please! ";
                                await new MessageDialog(msg).ShowAsync();
                            }

                        }
                        else
                        {
                            string msg = "$ please type correct password! ";
                            await new MessageDialog(msg).ShowAsync();
                        }

                    }
                }

            }
        }

        private void UP_back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
