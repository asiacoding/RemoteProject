using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp1
{
    public partial class App : Application
    {
        public App()
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
