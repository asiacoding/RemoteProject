using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp
{
    public partial class Application : Xamarin.Forms.Application
    {
        public Application()
        {
            InitializeComponent();

            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense( 
            //   "NjI1MDYzQDMyMzAyZTMxMmUzMEVRNzg2VU54bEp3OXVlM2tTZXdKb3BQWWREa1UwRUpZY3NGVmlkRUNVQUk9");

            MainPage = new NavigationPage(new Home());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }



        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            try
            {
                base.OnAppLinkRequestReceived(uri);
                var CheckWebLink = uri.Segments;
                // Spliet to '/'  

                if (CheckWebLink.Length >= 2)
                {
                    string Code = CheckWebLink[1];
                    if(Code.ToLower() == "msgcenter/")
                    {
                        MessagingCenter.Send<string,string>(Home.TargetObject,"SentToHomePage" ,CheckWebLink[2]);
                    }
                }






            }
            catch (Exception ex)
            {
                string I = ex.Message;
            }
        }


    }
}
