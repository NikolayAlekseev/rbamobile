using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Rbauto.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "О компании";

            GotoSiteCommand = new Command(() => Device.OpenUri(new Uri(@"http://www.rbauto.ru/")));
        }

        public Command GotoSiteCommand { get; set; }
    }
}
