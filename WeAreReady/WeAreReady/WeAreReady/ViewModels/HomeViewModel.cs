using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreReady.Model;
using Xamarin.Forms;

namespace WeAreReady.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Alert> Alerts { get; set; }
        public HomeViewModel()
        {
            Alerts = new ObservableCollection<Alert>();
            Alerts.Add(new Alert{AlertKind = Alert.Kind.Fire, Title = "Wildfire spreading south. Move North.", Desc = "We have reports of wildfire in your locality spreading South very fast. Move North for safety."});
            Alerts.Add(new Alert { AlertKind = Alert.Kind.Flood,Title = "Earthquake of 3.7M was felt in A31 region.", Desc = "We have reports of Earthquake in your locality" });
            Alerts.Add(new Alert
            {
                AlertKind = Alert.Kind.Fire,
                Title = "Expected inflow 2000 by tomorrow",
                Desc =
                    "Because of flood and landslides in the area, we are expecting atleast 2000 people coming to Reguge camp 1 tomorrow. We request you to be made yourselves available during these difficult times. We appreciate your time and effort. Thanks"
            });
            Alerts.Add(new Alert
            {
                AlertKind = Alert.Kind.Fire,
                Title = "Hints of floods and possible Landslides expected in region A21.",
                Desc =
                    "Based on premilinary onsite reviews and weather forecasts, we expect a flood in region A21, and possible landslides along the mountain road in the region. We have alerted local authorities. You are requested to call if you are planning to be available for rescue duty, 2 days from now."
            });
            
        }
    }
}
