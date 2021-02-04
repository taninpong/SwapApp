using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Open_newApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var appname = @"com.scb.iphone";
            var result = await DependencyService.Get<IAppHandler>().LaunchApp(appname);
        }

        private async void Button_Clicked2(object sender, EventArgs e)
        {
            string url = string.Empty;
            var location = RegionInfo.CurrentRegion.Name.ToLower();
            if (Device.RuntimePlatform == Device.Android)
                url = "https://play.google.com/store/apps/details?id=com.sisystems.Sisystems";
            else if (Device.RuntimePlatform == Device.iOS)
                url = "https://itunes.apple.com/" + location + "/app/contractor-action-solution/id1039202852?mt=8";
            await Browser.OpenAsync(url, BrowserLaunchMode.External);
        }

        private void Button_Clicked3(object sender, EventArgs e)
        {
            DependencyService.Get<IAppHandler>().OpenExternalApp(input.Text);
        }
    }
}
