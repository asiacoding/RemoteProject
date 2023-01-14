using BlueApp1.Interface;
using BlueApp1.UIRemote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        private static IBlueServices ServicesBLUE = null;
        public Home()
        {
            InitializeComponent();

 
            if (ServicesBLUE == null)
            {
                ServicesBLUE = DependencyService.Get<IBlueServices>(); // In Start App . Connect BT Def 
            }

            RefLayoutConnectToBT();

           // ConnectBtn.Text = ServicesBLUE.IsConnect ? "Connected" : "Connect"; // Check And Set Output to User ..

            // MessagingCenter.Subscribe<Xamarin.Forms.Application, string>//(Xamarin.Forms.Application.Current, "OpenPage", (snd, arg) =>
            // {
            //     Device.BeginInvokeOnMainThread(() => { LastButton.Text = arg; });
            // });

        }

        private async void opneControl(object sender, EventArgs e)
        {
            try
            {
                if (ServicesBLUE.IsConnect)
                {
                    this.GOTO(TO: new RemoteUI());
                }
                else
                {
                    string action = await DisplayActionSheet("You are not connected to a device now, do you want to connect ?", "cancel", null, "Connect", "Back", "skip");
                    if (action == "Connect")
                    {
                        bool CheckConnecting = await ServicesBLUE.Connect();
                        RefLayoutConnectToBT();
                    }
                    else if (action == "skip")
                    {
                        this.GOTO(TO: new RemoteUI());
                    }
                }
            }
            catch (Exception ex)
            {
                Notes.Text = ex.Message;
            }
        }

        private void RefLayoutConnectToBT()
        {
            if(ServicesBLUE == null)
            {
                ConnectBtn.Text = "Connect";
                Notes.Text = "";
                return;
            }

            Notes.Text = ServicesBLUE.IsConnect ? "The connection has been restored successfully" : "An error occurred, please try again";
            ConnectBtn.Text = ServicesBLUE.IsConnect ? "Connected" : "Connect";
        }

        private async void Checkconnect(object sender, EventArgs e)
        {
            try
            {
                bool CheckConnecting = await ServicesBLUE.Connect();
                Notes.Text = CheckConnecting ?
                    "A device has been connected" :
                    "An error occurred, please try again";
                ConnectBtn.Text = CheckConnecting ?
                    "Connected" :
                    "Try again";
            }
            catch (Exception ex)
            {
                this.SendAlert(ex.Message);
            }
        }

        private void GetDataFromUart(object sender, EventArgs e)
        {
        //    Models.Standard.Delete.RemotesButton DeleteObjRemote = new Models.Standard.Delete.RemotesButton();
        //    DeleteObjRemote.DeleteAll("1234");//Save Codes
        }

        private void AddNewProject(object sender, EventArgs e)
        {
            this.GOTO(TO: new AddingNewProject());
        }

        private async void ExitAppClick(object sender, EventArgs e)
        {
            try
            {
                bool? exitapp = await this.SendAlert(M: "Do you want out ?", Questions: new[] { "no", "yes" });

                if (exitapp == true)
                {
                    ISystemFunction MySetting = DependencyService.Get<ISystemFunction>();
                    MySetting.ExitApp();
                }
            }
            catch (Exception)
            {
            }
        }


    }
}