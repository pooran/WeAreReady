using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreReady.ViewModels;
using Xamarin.Forms;

namespace WeAreReady.Views
{
    public class BaseView : ContentPage
    {
        public BaseView()
        {
            
            SetBinding(Page.TitleProperty, new Binding(BaseViewModel.TitlePropertyName));
            SetBinding(Page.IconProperty, new Binding(BaseViewModel.IconPropertyName));
        }

        
    }
}
