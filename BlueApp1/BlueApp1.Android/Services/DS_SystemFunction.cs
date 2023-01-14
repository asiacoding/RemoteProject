using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using Xamarin.Forms;
using BlueApp1.Droid.Services;
using Android.Graphics;
using System.IO;

[assembly: Dependency(typeof(DS_SystemFunction))]
namespace BlueApp1.Droid.Services
{

    public class DS_SystemFunction : Interface.ISystemFunction
    {
        Activity ContextActivitys = (Activity)Forms.Context;

//        Activity ContextActivitys = (Activity)Forms.Context;

        public void ClassicMessage(string Text) // it is no work !!! 
        {
            _ = Toast.MakeText(MainActivity.MainActivitY, Text + ";", ToastLength.Short);
            _ = Toast.MakeText(MainActivity.MainActivitY.ApplicationContext, Text + ";", ToastLength.Short);
            _ = Toast.MakeText(ContextActivitys, Text + ";", ToastLength.Short);
        }

        public byte[] Capture()
        {
            try
            {
                Android.Views.View rootView = ContextActivitys.Window.DecorView.RootView;
                using (Bitmap screenshot = Bitmap.CreateBitmap(
                                        rootView.Width,
                                        rootView.Height,
                                        Bitmap.Config.Argb8888))
                {
                    Canvas canvas = new Canvas(screenshot);
                    rootView.Draw(canvas);

                    using (MemoryStream stream = new MemoryStream())
                    {
                        screenshot.Compress(Bitmap.CompressFormat.Png, 90, stream);
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                //ex.InitException(InartSceen: false);
                return new byte[] { };
            }
        }

        public void ExitApp()
        {
            ContextActivitys.FinishAffinity();
            Process.KillProcess(Process.MyPid());
        }

        public string GetHardwareButton()
        {
            return !string.IsNullOrEmpty(MainActivity.HardwareTapsNow) ? MainActivity.HardwareTapsNow : "NULL";
        }

        public string GetIDDevices()
        {
            return Android.Provider.Settings.Secure.GetString(ContextActivitys.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
        }

        public void SetMsg(string Message)
        {
            Toast.MakeText(ContextActivitys, Message, ToastLength.Long);
        }

        public void SandSmsToWAppAsync(string message, string phoneNumberWithCountryCode)
        {
            try
            {
                ContextActivitys.StartActivity(new Intent(Android.Content.Intent.ActionView, Android.Net.Uri.Parse(
                    $"https://api.whatsapp.com/send?phone={phoneNumberWithCountryCode}&text={message}")));
            }
            catch (Exception)
            {
               // ex.InitException();
            }
        }

        public void OpenAppSettings()
        {
            try
            {
                var intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings);
                intent.AddFlags(ActivityFlags.NewTask);
                intent.SetData(Android.Net.Uri.FromParts("package", Xamarin.Essentials.AppInfo.PackageName, null) /* Get Name Package From  */);
                Android.App.Application.Context.StartActivity(intent);
            }
            catch (Exception)
            {
               // ex.InitException();
            }
        }



    }
}