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

        public ReportView()
        {
            var scroll = new ScrollView();
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
                var tapGesture = new TapGestureRecognizer { Command = new Command(AlertTap), CommandParameter = image };
                image.GestureRecognizers.Add(tapGesture);
                layout.Children.Add(image);
            }

            //scroll.BackgroundColor = Color.Purple;
            //scroll.Content = layout;
            Content = layout;
        }

        private void AlertTap(object imgObj)
        {
            var img = imgObj as Image;
            if (img != null)
            {
                img.BackgroundColor = Color.Gray;
            }
        }
    }
}
