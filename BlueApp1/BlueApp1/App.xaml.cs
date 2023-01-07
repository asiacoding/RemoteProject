using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp1
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
    }
}
