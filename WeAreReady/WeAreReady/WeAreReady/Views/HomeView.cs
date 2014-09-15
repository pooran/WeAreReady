using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeAreReady.Model;
using WeAreReady.ViewModels;
using Xamarin.Forms;

namespace WeAreReady.Views
{
    public class HomeView : BaseView
    {
        protected HomeViewModel ViewModel
        {
            get
            {
                return BindingContext as HomeViewModel;
            }
        }
        public HomeView()
        {
            
            Title = "Home";
            BindingContext = new HomeViewModel();

            var listView = new ListView(); 
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            listView.ItemTemplate = new DataTemplate(() =>
            {
                // Create views with bindings for displaying each property.
                var titleLabel = new Label();
                titleLabel.Font = Font.OfSize ("Segoe UI", 25 ).WithAttributes(FontAttributes.Bold);
                
                titleLabel.SetBinding(Label.TextProperty, "Title");

                var descLabel = new Label();
                descLabel.SetBinding(Label.TextProperty, "Desc");

                BoxView boxView = new BoxView();
                boxView.Color = Color.Red;

                // Return an assembled ViewCell.
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            boxView,
                            new StackLayout
                            {
                                VerticalOptions = LayoutOptions.Center,
                                Spacing = 0,
                                Children =
                                {
                                    titleLabel,
                                    descLabel
                                }
                            }
                        }
                    }
                };
            });
            listView.ItemsSource = ViewModel.Alerts;

            var te = Device.OnPlatform(
            ImageSource.FromFile("Images/disaster-01.png"),
            ImageSource.FromFile("disaster-01.png"),
            ImageSource.FromFile("Assets/disaster-01.png"))
            ;

            var image = new Image { Source = Data.GetImageSource("disaster-01"), Aspect = Aspect.AspectFit };
            var refresh = new ToolbarItem
            {
                Icon = String.Format("{0}{1}.png", Device.OnPlatform("Images/", "", ""), "disaster-01"),
                Name = "refresh",
                Priority = 0
            };
            //var temp = Device.OnPlatform(
            //    FileImageSource.FromFile("Images/disaster-01.jpg"),
            //    FileImageSource.FromFile("disaster-01.jpg"),
            //    FileImageSource.FromFile("Assets/disaster-01.png"));
            //refresh.Icon = "Assets/disaster-01.png";

            ToolbarItems.Add(refresh);
            //Content = new StackLayout
            //{
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    Children = { image }
            //};

            Content = image;
        }
    }
}
