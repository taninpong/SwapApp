using Foundation;
using Open_newApp.iOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppHandler))]
namespace Open_newApp.iOS
{
    public class AppHandler : IAppHandler
    {
        public Task<bool> LaunchApp(string packageName)
        {
            try
            {
                var canOpen = UIApplication.SharedApplication.CanOpenUrl(new NSUrl(packageName));
                if (!canOpen)
                    return Task.FromResult(false);
                return Task.FromResult(UIApplication.SharedApplication.OpenUrl(new NSUrl(packageName)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
        public void OpenExternalApp(string packageName)
        {
            //NSUrl request = new NSUrl("yourapp://");
            NSUrl appURL;
            string appURI;
            appURL = new NSUrl("NowClinic://");
            appURI = "https://itunes.apple.com/us/app/nowclinic/id602339098?mt=8";
            try
            {
                bool isOpened = UIApplication.SharedApplication.OpenUrl(appURL);

                if (isOpened == false)
                    UIApplication.SharedApplication.OpenUrl(new NSUrl(appURI));
            }
            catch (Exception ex)
            {
                var alertView = new UIAlertView("Error", ex.Message, null, "OK", null);
                alertView.Show();
            }
        }
    }
}