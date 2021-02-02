using Android.App;  
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Open_newApp.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenAppAndroid))]
namespace Open_newApp.Droid
{
    public class OpenAppAndroid : IAppHandler
    {
        public Task<bool> LaunchApp(string packageName)
        {
            bool result = false;

            PackageManager pm = Android.App.Application.Context.PackageManager;

            Intent intent = pm.GetLaunchIntentForPackage(packageName);

            try
            {
                if (IsAppInstalled(packageName))
                {
                    if (intent != null)
                    {
                        intent.SetFlags(ActivityFlags.NewTask);
                        Android.App.Application.Context.StartActivity(intent);
                    }
                }
                else  
                {
                    intent = new Intent(Intent.ActionView);
                    intent.AddFlags(ActivityFlags.NewTask);
                    intent.SetData(Android.Net.Uri.Parse("market://details?id=com.kasikorn.retail.mbanking.wap"));
                    Android.App.Application.Context.StartActivity(intent);
                }
            }
            catch (ActivityNotFoundException)
            {
                result = false;
            }

            return Task.FromResult(result);
        }

        private bool IsAppInstalled(string packageName)
        {
            PackageManager pm = Android.App.Application.Context.PackageManager;
            bool installed = false;
            try
            {
                pm.GetPackageInfo(packageName, PackageInfoFlags.Activities);
                installed = true;
            }
            catch (PackageManager.NameNotFoundException e)
            {
                installed = false;
            }

            return installed;
        }
    }
}