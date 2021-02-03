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
    }
}