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
                ServicesBLUE = DependencyService.Get<IBlueServices>();

   
            ConnectBtn.Text = ServicesBLUE.IsConnect ?
                "متصل" :
                "اتصال";


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
                    bool CheckConnecting = await ServicesBLUE.Connect();
                    Notes.Text = CheckConnecting ?
                        "يرجى الاتصال بجهاز أولا" :
                        "حدث خطا الرجاء المحاولة مره أخرى";
                    ConnectBtn.Text = CheckConnecting ?
                        "متصل" :
                        "حاول مجددا";
                }
            }
            catch (Exception ex)
            {
                Notes.Text = ex.Message;
            }
        }

        private async void Checkconnect(object sender, EventArgs e)
        {
            try
            {
                if (!ServicesBLUE.IsConnect) //Check is connect or no
                {
                    bool CheckConnecting = await ServicesBLUE.Connect();
                    Notes.Text = CheckConnecting ?
                        "تم الاتصال بجهاز" :
                        "حدث خطا الرجاء المحاولة مره أخرى";
                    ConnectBtn.Text = CheckConnecting ?
                        "متصل" :
                        "حاول مجددا";

                    //  ServicesBLUE.Connect(); Notes.Text = "";
                }
                else
                {
                    Notes.Text = "انت بالفعل على متصل";
                }
            }
            catch (Exception)
            {
            }
        }

        private void GetDataFromUart(object sender, EventArgs e)
        {
            Models.Standard.Delete.RemotesButton DeleteObjRemote = new Models.Standard.Delete.RemotesButton();
            DeleteObjRemote.DeleteAll("1234");//Save Codes
        }

        private void AddNewProject(object sender, EventArgs e)
        {
            this.GOTO(new UIRemote.AddingNewProject());
        }

        private void AvailableChannels(object sender, EventArgs e)
        {

        }
    }
}