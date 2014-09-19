using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreReady.CustomControl;
using WeAreReady.Model;
using Xamarin.Forms;

namespace WeAreReady.Views
{
    public class ReportView : ContentPage
    {

        private Grid MainGrid;
        private string SelectedImage = "";
        Entry entry = new Entry();
        Button submitButton = new Button();

        public ReportView()
        {
            var scroll = new ScrollView();

            MainGrid = new Grid();
            MainGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            MainGrid.HorizontalOptions = LayoutOptions.FillAndExpand;

            Content = MainGrid;

            BuildLayout();
        }

        private void BuildLayout()
        {
            Grid grid1 = new Grid();
            grid1.VerticalOptions = LayoutOptions.FillAndExpand;
            grid1.HorizontalOptions = LayoutOptions.FillAndExpand;

            RowDefinition row1 = new RowDefinition();
            row1.Height = new GridLength(1, GridUnitType.Star);

            RowDefinition row2 = new RowDefinition();
            row2.Height = GridLength.Auto;

            grid1.RowDefinitions.Add(row1);
            grid1.RowDefinitions.Add(row2);

            var layout = new WrapLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                Spacing = 20,
                Orientation = StackOrientation.Horizontal,
            };

            for (int i = 0; i < 8; i++)
            {
                var imgStr = "disaster-0" + (i + 1);
                var image = new Image
                {
                    Source = Data.GetImageSource(imgStr),
                    Aspect = Aspect.AspectFit,
                    WidthRequest = 100,
                    HeightRequest = 100
                };

                ImageWithInfo iWI = new ImageWithInfo
                {
                    Info = imgStr,
                    Image = image
                };

                var tapGesture = new TapGestureRecognizer { Command = new Command(AlertTap), CommandParameter = iWI };
                image.GestureRecognizers.Add(tapGesture);
                layout.Children.Add(image);
            }

            grid1.Children.Add(layout);



            Grid grid2 = new Grid();
            ColumnDefinition grid2Column0 = new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Star),
            };
            ColumnDefinition grid2Column1 = new ColumnDefinition()
            {
                Width = GridLength.Auto,
            };
            grid2.HorizontalOptions = LayoutOptions.FillAndExpand;

            grid2.Children.Add(entry);
            entry.HorizontalOptions = LayoutOptions.FillAndExpand;
            
            Grid.SetColumn(entry, 0);

            
            submitButton.Text = "Submit";
            submitButton.IsEnabled = false;
            var tapSubmit = new TapGestureRecognizer
            {
                Command = new Command(SubmitTap),
                CommandParameter = SelectedImage
            };
            submitButton.GestureRecognizers.Add(tapSubmit);
            grid2.Children.Add(submitButton);
            Grid.SetColumn(submitButton, 1);

            grid1.Children.Add(grid2);
            Grid.SetRow(grid2, 1);

            MainGrid.Children.Add(grid1);
            
        }

        private async void SubmitTap(object submitTapString)
        {
            Alert alert = new Alert();
            string textToSubmit = SelectedImage;
            int disasterCase = Convert.ToInt32(textToSubmit.Split('-')[1]);
            switch (disasterCase)
            {
                case 1:
                    alert.AlertKind = Alert.Kind.Avalanche;
                    break;
                case 2:
                    alert.AlertKind = Alert.Kind.Tornado;
                    break;
                case 3:
                    alert.AlertKind = Alert.Kind.Fire;
                    break;
                case 4:
                    alert.AlertKind = Alert.Kind.Blizzard;
                    break;
                case 5:
                    alert.AlertKind = Alert.Kind.Flood;
                    break;
                case 6:
                    alert.AlertKind = Alert.Kind.Thunder;
                    break;
                case 7:
                    alert.AlertKind = Alert.Kind.Flood;
                    break;
                case 8:
                    alert.AlertKind = Alert.Kind.Fire;
                    break;
                case 9:
                    alert.AlertKind = Alert.Kind.Earthquake;
                    break;
                default:
                    alert.AlertKind = Alert.Kind.Thunder;
                    break;
            }

            
            string description = entry.Text;

            alert.Desc = description;
            alert.Title = alert.AlertKind.ToString();
            alert.When = 0;

            App.homeViewModel.Alerts.Add(alert);

            //TODO: Submit Alert
            //await StaticMethod.GetHttpAsStringAsync(API);
        }

        private async void AlertTap(object obj)
        {

            ImageWithInfo imageWithInfo = obj as ImageWithInfo;

            if(imageWithInfo.Image != null)
            {
                imageWithInfo.Image.BackgroundColor = Color.Gray;
                submitButton.IsEnabled = true;
            }

            SelectedImage = imageWithInfo.Info as string;

            //await Navigation.PushAsync(new ReportXAMLView());
        }
    }

    public class ImageWithInfo
    {
        public string Info { get; set; }
        public Image Image { get; set; }
    }
}
