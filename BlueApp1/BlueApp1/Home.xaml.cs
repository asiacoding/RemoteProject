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
        interface_enum.SpeechToText speechToText;
        private readonly IBlueServices ServicesBLUE = null;
        public Home()
        {
            InitializeComponent();
            ServicesBLUE = DependencyService.Get<IBlueServices>();

            speechToText = new interface_enum.SpeechToText(new interface_enum.IMessageSenderDoWork.EventHandler(delegate (string i, string i2)
            {
                this.SandAlert(String.Format("Res:{0},Log:{1}", i, i2));
            }));

        }

        private void opneControl(object sender, EventArgs e)
        {
            if (ServicesBLUE.IsConnect)
            {
                this.GOTO(new UIRemote.RemoteUI());
            }
            else
            {
                Notes.Text = "Please contact my device first";
            }
        }

        private void Checkconnect(object sender, EventArgs e)
        {
            //Check is connec or no
            if (!ServicesBLUE.IsConnect)
            {
                ServicesBLUE.Connect();
                Notes.Text = "You are now connected to a device.";
            }
            else
            {
                Notes.Text = "You are already online";
            }
        }

        private void GetDataFromUart(object sender, EventArgs e)
        {
            // ServicesBLUE.Write("AddNewKey;");
            //var GetDtat = await ServicesBLUE.BluetoothListeningforOne();
            //this.SandAlert(GetDtat);
            // if (ServicesBLUE.IsConnect)
            // {
            //     this.GOTO(new AddingNewProject());
            // }
            // else
            // {
            //     Notes.Text = "Please contact my device first";
            // }
            if (speechToText != null)
                speechToText.Start();

        }
    }
}