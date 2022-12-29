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
        Interface.ISystemFunction SystemFunction = Xamarin.Forms.DependencyService.Get<Interface.ISystemFunction>();
        private readonly IBlueServices ServicesBLUE = null;
        public Home()
        {
            InitializeComponent();
            ServicesBLUE = DependencyService.Get<IBlueServices>();
        }

        private void opneControl(object sender, EventArgs e)
        {
            if (ServicesBLUE.IsConnect)
            {
                this.GOTO(new UIRemote.RemoteUI());
            }
            else
            {
                ///Please contact my device first
               // SystemFunction.ClassicMessage();
                Notes.Text = "يرجى الاتصال بجهاز أولا";
            }
        }

        private void Checkconnect(object sender, EventArgs e)
        {
            try
            {
                //Check is connec or no
                if (!ServicesBLUE.IsConnect)
                {
                    ServicesBLUE.Connect();

                    Notes.Text = "تم الاتصال بجهاز";
                }
                else
                {
                    Notes.Text = "انت بالفعل على متصل";
                    SystemFunction.ClassicMessage("Weclome");
                }
            }
            catch (Exception ex)
            {
                //
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

            Models.Standard.Delete.RemotesButton DeleteObjRemote = new Models.Standard.Delete.RemotesButton();
            DeleteObjRemote.DeleteAll("1234");//Save Codes
        }
    }
}