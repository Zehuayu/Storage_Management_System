using System;
using Storage_Management_System.Database;
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
using System.Collections.ObjectModel;


namespace Storage_Management_System
{

    public sealed partial class GoodsPage : Page
    {

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
                        Supplier = iteam.Supplier


                    });
                }
            }

        }

        public class Recording
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Amount { get; set; }

            public string Price { get; set; }

            public string Supplier { get; set; }



        }



       

        public void delete(string Name)
        {
            
            using (var conn = DatabaseConnection.GetDbConnectionone())
            {
                conn.Execute("DELETE FROM Goods Where Name = ?", Name);

            }


        }

        private void g_add(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StorageAddPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void G_delete(object sender, RoutedEventArgs e)
        {
            string i;
            i = d_input.Text;
            delete(i);

          this.Frame.Navigate(typeof(GoodsPage));
        }
    }
}
