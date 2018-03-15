using System;

using Xamarin.Forms;

namespace Storage_Client
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page itemsPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Menu"
                    };

                   
                    itemsPage.Icon = "tab_feed.png";
                   
                    break;
                default:
                    itemsPage = new ItemsPage()
                    {
                        Title = "Menu"
                    };

                   
                    break;
            }

            Children.Add(itemsPage);
           

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
