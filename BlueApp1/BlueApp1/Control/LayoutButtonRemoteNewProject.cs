using BlueApp.interface_enum;
using BlueApp.UIRemote;
using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using static BlueApp.UIRemote.SetupScreenRemotely;
namespace BlueApp.Control
{
    internal class ButtonsUI : StackLayout, IMessageSender
    {
        public StackLayout OwnerLayout { set; get; }
        public bool StutsMode = false;
        ImageButton SetIR = new ImageButton();
        Label Lbl = new Label();
        public RemoteButtonModels RemoteModels;
        Picker Data = new Picker();
        private readonly string[] ListMeunButton =
        {
            "From Device",
            "Manual Code",
            "Delete",
        };
        //-------------------------------------------------------------------------------------------------------
        public ButtonsUI(string Guid, string LayoutName)
        {
            try
            {
                //------------------------------------------- init Full Control 
                RemoteModels = new RemoteButtonModels()
                {
                    Guid = Guid,
                    Name = LayoutName
                };
                SetIR = new ImageButton()
                {
                    Source = "menuP1",
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };
                Data = new Picker()
                {
                    Title = "Menu",
                    IsVisible = false,
                    BackgroundColor = Color.LightSteelBlue,
                    ItemsSource = ListMeunButton.ToList(),
                };
                Lbl = new Label()
                {
                    Text = LayoutName,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    BackgroundColor = Color.FromHex("#eee")
                };
                //------------------------------------------- Event
                Data.SelectedIndexChanged += Data_SelectedIndexChanged; // 
                SetIR.Clicked += SetIR_Clicked;
                //------------------------------------------- Main Page Propert
                Orientation = StackOrientation.Horizontal;
                HeightRequest = 60;
                BackgroundColor = Color.FromHex("#eee");
                //------------------------------------------- Set Control To Stacklayout
                Children.Add(Lbl);
                Children.Add(SetIR);
                Children.Add(Data);
                //-------------------------------------------
            }
            catch (Exception ex)
            {
                this.CurrentPage().SendAlert(ex.Message);
            }
        }
        private void Data_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Data.SelectedIndex == 0)
                {
                    FromDevice();
                }
                else if (Data.SelectedIndex == 1)
                {
                    FromManual();
                }
                else if (Data.SelectedIndex == 2)
                {
                    Deleting();
                    // this.CurrentPage().DisplayErrorAlert();
                }

            }
            catch (Exception ex)
            {
                this.CurrentPage().SendAlert(ex.Message);
            }
        }
        private async void FromDevice()
        {
            //Set Com To Devise BT
            //Take a new sample of the signals
            try
            {
                if (StutsMode) //
                {
                    return;
                }

                if (!BlueServices.IsSupportBT)
                {
                    return;
                }

                if (!blueServices.IsConnect) // Check Connect 
                {
                    var SendAlerd = await this.CurrentPage().SendAlert("You are not connected to the device. Do you want to reconnect now?", new[] { "No", "Yes" });
                    if (SendAlerd.Value)
                    {
                        var CheckConnect = await blueServices.Connect();
                        if (!CheckConnect) { this.CurrentPage().SendAlert("The connection was not successful, please try again"); return; }
                    }
                    else
                    {

                        return;
                    }
                }

                //----------------------------------------------------------------
                //GetCodes; [ is Get in Verions 1.0.0.0 ] 
                BlueServices.Write("GetCodes;"); //Rest command 
                string WaitingData = await BlueServices.BluetoothListeningforOne(AfterListeningConnect: true);

                if (WaitingData.Contains("Error"))
                {
                    this.CurrentPage().DisplayErrorAlert();
                    return;
                }

                if (!string.IsNullOrEmpty(WaitingData))
                {
                    if (RemoteModels != null)
                    {
                        RemoteModels.Codes = WaitingData;
                        RemoteModels.ModelRemote = "";
                        //SetIR.so = "Ok"; // 
                        StutsMode = true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.CurrentPage().SendAlert(ex.Message);
            }

        }
        async void FromManual()
        {
            try
            {

                if (StutsMode)
                {
                    var checkedO = await this.CurrentPage().SendAlert("You already entered this code. Do you want to enter another code?", new[] { "No", "yes" });
                    if (!checkedO.Value) { return; }
                }

                string Str = await this.CurrentPage().DisplayPromptAsync("", "" +
                    "Add IR Code \n" +
                    "___________\n\t\tTypeing IR Code (Number only Or Hex Code (Add Code '0x Number')", accept: "Create", placeholder: "Exmple 16500123 or 0x10d012a ...", maxLength: 40, keyboard: Keyboard.Text);

                if (!string.IsNullOrEmpty(Str))
                {
                    if (Str.ToLower().Contains("0x"))
                    {
                        Str = int.Parse(Str.ToLower().Replace("0x", ""), System.Globalization.NumberStyles.HexNumber).ToString();
                        //                            Convert.ToInt64(Str, 16).ToString();
                    }

                    if (RemoteModels != null)
                    {
                        RemoteModels.Codes = Str;
                        RemoteModels.ModelRemote = "";
                        StutsMode = true;
                    }

                }
                else
                {

                }

            }
            catch (Exception)
            {
            }
        }
        //private void TestHexDec()
        //{
        //----------int decValue = 182;
        //----------Convert integer 182 as a hex in a string variable
        //----------string hexValue = decValue.ToString("X");
        //----------Convert the hex string back to the number
        //----------int decAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
        //----------string Code2 = string.Format("{0:x}", "16773120"); // fff000
        //----------object Code = Convert.ToInt64("fff000", 16); //16773120
        //}
        private void SetIR_Clicked(object sender, EventArgs e)
        {
            try
            {
                Data.Focus();
            }
            catch (Exception ex)
            {
                this.CurrentPage().SendAlert(ex.Message);
            }

        }
        private void Deleting()
        {
            if (BasePageControl != null)
            {
                MessagingCenter.Send<IMessageSender, StackLayout>(BasePageControl, "DeletingButton", this);
            }
        }



    }
}
