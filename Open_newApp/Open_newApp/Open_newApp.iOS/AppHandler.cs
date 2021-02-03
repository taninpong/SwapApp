using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

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
            NSUrl request = new NSUrl("yourapp://");

            try
            {
                bool isOpened = UIApplication.SharedApplication.OpenUrl(request);

                if (isOpened == false)
                    UIApplication.SharedApplication.OpenUrl(new NSUrl("yourapp://com.kasikorn.retail.mbanking.wap"));
            }
            catch (Exception ex)
            {
                var alertView = new UIAlertView("Error", ex.Message, null, "OK", null);
                alertView.Show();
            }
        }
    }
}