using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Android.Speech;
using Android.Content;
using Android.Views;
using BlueApp.interface_enum;

namespace BlueApp.Droid
{
    [Activity( 
        Label = "Magical Stick",
        Icon = "@drawable/Logo", 
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = 
        ConfigChanges.ScreenSize |
        ConfigChanges.Orientation | 
        ConfigChanges.UiMode |
        ConfigChanges.ScreenLayout |
        ConfigChanges.SmallestScreenSize)]

    [IntentFilter(
        new[] { Android.Content.Intent.ActionView, }, //https://MagicalStick.Blocking/MsgCenter/Code
        DataScheme = "https",
    //    DataMimeTypes = new[] {"text/plne","" },
        DataHost = "MagicalStick.Remotely.Teleportation", // https://WebHostLin/AndroidApp
        DataPathPrefix = "/",
        AutoVerify = true,
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.ActionView, })]

    [IntentFilter( //file:///storage/emulated/0/MyFile.html
        new[] { Android.Content.Intent.ActionView, }, //https://MagicalStick.Blocking/MsgCenter/Code
        DataScheme = "intent",
    //    DataMimeTypes = new[] {"text/plne","" },
    //ile:///storage/emulated/0/IMG-20221218-WA0000.jpg
        DataHost = "MagicalStick.Remotely.Teleportation", // https://WebHostLin/AndroidApp
        DataPathPrefix = "/",
        AutoVerify = true,
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.ActionView
            })]

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





        #region Remove Border
        private void RemoveBorderApp()
        {
            #region Remove Border App
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.R)
            {
                Window.SetDecorFitsSystemWindows(false);
            }
            else
            {
                StatusBarVisibility option = (StatusBarVisibility)SystemUiFlags.LayoutFullscreen | (StatusBarVisibility)SystemUiFlags.LayoutStable;
                Window.DecorView.SystemUiVisibility = option;
                int uiOptions = (int)Window.DecorView.SystemUiVisibility;
                uiOptions |= (int)SystemUiFlags.Fullscreen;
                uiOptions |= (int)SystemUiFlags.HideNavigation;
                uiOptions |= (int)SystemUiFlags.ImmersiveSticky;
                uiOptions |= (int)SystemUiFlags.LayoutHideNavigation;
                uiOptions |= (int)SystemUiFlags.LayoutFullscreen;
                uiOptions |= (int)SystemUiFlags.LayoutStable;
                WindowManagerLayoutParams lp = Window.Attributes;
                lp.WindowAnimations = 1;
                lp.X = 0;
                lp.Y = 0;
                lp.Flags = WindowManagerFlags.Fullscreen;
                lp.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            }
            Window.AddFlags(WindowManagerFlags.Fullscreen);//
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);//DrawsSystemBarBackgrounds
            Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            #endregion
        }
        #endregion




    }
}