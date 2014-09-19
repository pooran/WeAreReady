using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeAreReady.Model
{
    public class Data
    {

        public static ImageSource GetImageSource(string img)
        {
            return ImageSource.FromResource("WeAreReady.Images." + img + ".png");
        }

        /*
         * FileImageSource AppBarIcon Platform Specific
         */
        public static string GetIconSource(string img)
        {
            return "WeAreReady.Images." + img;
        }
    }

    public class Alert
    {
        public enum Kind { Flood, Fire, Avalanche, Tsunami, Blizzard, Biological, Earthquake, Tornado, Thunder };

        public string Title { get; set; }
        public string Desc { get; set; }

        public long When { get; set; }
        public Kind AlertKind { get; set; }
    }

    public class CheckPoint
    {
        public string Name { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
    }

    public class Org
    {
        public string OrgId { get; set; }
        public string OrgName { get; set; }
        public string Description { get; set; }
        public string ContactNumbers { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
    }

    public class Disaster
    {
        public string DisasterId { get; set; }
        public string DisasterName { get; set; }
    }
}
