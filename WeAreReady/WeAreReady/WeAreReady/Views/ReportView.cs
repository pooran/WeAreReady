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

        public ReportView()
        {
            var scroll = new ScrollView();

            MainGrid = new Grid();
            MainGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            MainGrid.HorizontalOptions = LayoutOptions.FillAndExpand;

            Content = MainGrid;

            BuildLayout();

            //var layout = new WrapLayout
            //{
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Start,
            //    Spacing = 20,
            //    Orientation = StackOrientation.Horizontal,
            //};

            //for (int i = 0; i < 8; i++)
            //{
            //    var imgStr = "disaster-0" + (i + 1);
            //    var image = new Image
            //    {
            //        Source = Data.GetImageSource(imgStr),
            //        Aspect = Aspect.AspectFit,
            //        WidthRequest = 100,
            //        HeightRequest = 100
            //    };
            //    var tapGesture = new TapGestureRecognizer { Command = new Command(AlertTap), CommandParameter = imgStr };
            //    image.GestureRecognizers.Add(tapGesture);
            //    layout.Children.Add(image);
            //}

            ////scroll.BackgroundColor = Color.Purple;
            ////scroll.Content = layout;
            //Content = layout;
        }

        private void BuildLayout()
        {
            Grid grid1 = new Grid();
            grid1.VerticalOptions = LayoutOptions.FillAndExpand;
            grid1.HorizontalOptions = LayoutOptions.FillAndExpand;

            RowDefinition row1 = new RowDefinition();
            row1.Height = new GridLength(1, GridUnitType.Star);

            RowDefinition row2 = new RowDefinition();
            row2.Height = new GridLength(1, GridUnitType.Star);

            grid1.RowDefinitions.Add(row1);
            grid1.RowDefinitions.Add(row2);

            //Label test = new Label();
            //test.Text = "Hello world";
            //test.TextColor = Color.White;
            //grid1.Children.Add(test);
            //Grid.SetRow(test, 1);

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

            

            StackLayout stack = new StackLayout();
            stack.Orientation = StackOrientation.Horizontal;
            stack.HorizontalOptions = LayoutOptions.Center;

            
            entry.HorizontalOptions = LayoutOptions.FillAndExpand;
            stack.Children.Add(entry);            

            Button submitButton = new Button();
            submitButton.Text = "Submit";
            var tapSubmit = new TapGestureRecognizer
            {
                Command = new Command(SubmitTap),
                CommandParameter = SelectedImage
            };
            submitButton.GestureRecognizers.Add(tapSubmit);
            stack.Children.Add(submitButton);

            grid1.Children.Add(stack);
            Grid.SetRow(stack, 1);

            MainGrid.Children.Add(grid1);
            
        }

        private async void SubmitTap(object submitTapString)
        {
            string textToSubmit = SelectedImage;
            string description = entry.Text;

            //TODO: Submit Alert
            //await StaticMethod.GetHttpAsStringAsync(API);
        }

        private async void AlertTap(object obj)
        {

            ImageWithInfo imageWithInfo = obj as ImageWithInfo;

            if(imageWithInfo.Image != null)
            {
                imageWithInfo.Image.BackgroundColor = Color.Gray;
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
