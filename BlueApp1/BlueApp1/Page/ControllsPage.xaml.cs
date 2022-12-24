using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlueApp1
{
    public partial class ControllsPage : ContentPage
    {
        private readonly IBlueServices BlueServices;

        public ControllsPage()
        {
            try
            {
                InitializeComponent();
                BlueServices = DependencyService.Get<IBlueServices>();
                BlueServices.Reading += BlueServices_Reading;
                BlueServices.ClosedConnecting += BlueServices_ClosedConnecting; ;
                Connectbluet();
            }
            catch (Exception)
            {
                //Sned
            }
        }

        private void BlueServices_ClosedConnecting(object sender, object e)
        {
            runingApp(false);
        }


        void runingApp(bool Stusts)
        {

            Connect.IsVisible = !Stusts;
            Connect.IsEnabled = !Stusts;

            contectPanel_1.IsVisible = Stusts;
            contectPanel_1.IsEnabled = Stusts;
            contectPanel_2.IsVisible = Stusts;
            contectPanel_2.IsEnabled = Stusts;
        }


        private void BlueServices_Reading(object sender, object e)
        {


            if (e.ToString().Contains("a4:0"))
            {
               // NightImage.BackgroundColor = Color.Green;
               // SunImage.IsEnabled = false;
               // SunImage.IsEnabled = false;
               // SunImage.BackgroundColor = Color.FromHex("#eee");

                ChangeMode_A4(NightImage);
                Output.Text = "Command ' IR Sensor Interface ' " + DateTime.Now.ToString("ss:MM:hh (tt)");
            }
            else if (e.ToString().Contains("a4:1"))
            {
                ChangeMode_A4(SunImage);
                //  NightImage.BackgroundColor = Color.FromHex("#eee");
                //  SunImage.IsVisible = true;
                Output.Text = "Command ' IR Sensor Interface ' " + DateTime.Now.ToString("ss:MM:hh (tt)");
            }
            else
            {
                Output.Text = e.ToString();
            }

            BlueServices.Read();
        }

        void ChangeMode_A4(View ViewsTarget)
        {
            NightImage.IsVisible = false;
            SunImage.IsVisible = false;

            ViewsTarget.BackgroundColor = Color.Green;
            ViewsTarget.IsVisible = true;
            
            //ViewsTarget
        }






        private void Connectbluet()
        {
            var MyBlue = BlueServices.Devies();
            if (MyBlue.Count > 0)
            {
                if (MyBlue.Contains("IRremote"))
                {
                    BlueServices.Connect();
                    Connect.IsVisible = false;
                    runingApp(true);
                    //   BlueServices.Read();
                }
                else
                {
                    Connect.IsVisible = true;
                }
            }
            else
            {
                Connect.IsVisible = true;
            }
        }

        //Send
        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (BlueServices != null)
                {
                    BlueServices.Write(SetCode.Text+";");
                }
            }
            catch (Exception)
            {
            }
        }
        //Connect
        private void connect(object sender, EventArgs e)
        {
            try
            {
                Connectbluet();
            }
            catch (Exception)
            {
            }
        }

        private void ChangeValueButton(object sender, EventArgs e)
        {
            if (sender is CoustomButton GetButton)
            {

                if (GetButton.WriteMethod)
                    BlueServices.Write(GetButton.Code + ";");

                if (GetButton.ReadMethod)
                    BlueServices.Read();

            }
        }




    }
}
