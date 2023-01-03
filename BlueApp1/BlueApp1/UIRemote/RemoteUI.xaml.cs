using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp1.UIRemote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemoteUI : ContentPage
    {

        interface_enum.SpeechToText speechToText;
        public RemoteUI()
        {
            InitializeComponent();

            speechToText = new interface_enum.SpeechToText(new interface_enum.IMessageSenderDoWork.EventHandler(delegate (string i, string i2)
            {
                if (!string.IsNullOrEmpty(i))
                {
                    VoiceCode(i);
                }
            }));
            InitProjectButton();
        }

        void InitProjectButton()
        {
            cb_1.MainPageOwner =
            cb_2.MainPageOwner =
            cb_3.MainPageOwner =
            cb_4.MainPageOwner =
            cb_5.MainPageOwner =
            cb_6.MainPageOwner =
            cb_7.MainPageOwner =
            cb_8.MainPageOwner =
            cb_9.MainPageOwner =
            cb_0.MainPageOwner =
            cb_left.MainPageOwner =
            cb_up.MainPageOwner =
            cb_right.MainPageOwner =
            cb_power.MainPageOwner =
            cb_ok.MainPageOwner =
            cb_NoSound.MainPageOwner =
            cb_down.MainPageOwner = this;
        }




        private void ChangeMode(object sender, EventArgs e)
        {

        }

        private void SetKeyboard(object sender, EventArgs e)
        {
            changelayout(KeyboardPanel);
        }


        void changelayout(View view)
        {
            List<View> ControlReg = new List<View> { KeyboardPanel };
            ControlReg.ForEach(a => a.IsVisible = false);
            view.IsVisible = true;
        }

        private void MicroPhoneCode(object sender, EventArgs e)
        {
            if (speechToText != null)
            {
                speechToText.Start();
            }
        }

        private void VoiceCode(string Code)
        {
            // do Run Code
        }

        private void ChanelsList(object sender, EventArgs e)
        {
            this.GOTO(new BlueApp1.EventsPage.ChannelsListPage());
            //    <Button Text="القنوات المتاحة"  BackgroundColor="#75AE94" Clicked="AvailableChannels"  //Grid.Row="1"  TextColor="White" />
            //   <Image  Grid.Column="1" BackgroundColor="#75AE94" Source="control" Grid.Row="1" />
        }
    }
}