using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Android.Speech;
using Android.Content;
using Android.Views;
using BlueApp1.interface_enum;

namespace BlueApp1.Droid
{
    [Activity(Label = "Magical Stick", Icon = "@drawable/Logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IMessageSender
    {

        public static string HardwareTapsNow;
        public static Activity MainActivitY { private set; get; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            MainActivitY = this;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new Application());
        }


        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            HardwareTapsNow = keyCode.ToString();
           // MessagingCenter.Send(Xamarin.Forms.Application.Current, "OpenPage", keyCode.ToString());
            return base.OnKeyDown(keyCode, e);
        }






        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private readonly int VOICE = 10;
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {



            if (requestCode == VOICE)
            {
                if (resultCode == Result.Ok)
                {
                    var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                    if (matches.Count != 0)
                    {
                        string textInput = matches[0];
                        MessagingCenter.Send<IMessageSender, string>(this, "STT", textInput);
                    }
                    else
                    {
                        MessagingCenter.Send<IMessageSender, string>(this, "STT", null);
                    }

                }
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }

    }
}