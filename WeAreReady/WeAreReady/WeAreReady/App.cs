using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeAreReady.Views;
using Xamarin.Forms;

namespace WeAreReady
{
    public class App
    {
        public static Page GetMainPage()
        {

            var scanPage = new ContentPage
            {
                Title = "Scan",
                Content = new StackLayout
                {
                    Spacing = 20,
                    Padding = 50,
                    VerticalOptions = LayoutOptions.Center,
                    Children = 
                    {
                        new Entry { Placeholder = "Username" },
                        new Entry { Placeholder = "Password", IsPassword = true },
                        new Button 
                        {
                            Text = "Login",
                            TextColor = Color.Black,
                            BackgroundColor = Color.FromHex("77D065") 
                        }
                    }
                }
            };

            var messagePage = new ReportView
            {
                Title = "Report"
            };

            var homeView = new HomeView();


            var mainView = new NavigationPage(new TabbedPage { Children = { homeView, scanPage, messagePage } });

            return mainView;
        }
    }
}