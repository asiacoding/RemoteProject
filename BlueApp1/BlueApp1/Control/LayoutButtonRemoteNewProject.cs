using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using static BlueApp1.UIRemote.SetupScreenRemotely;
namespace BlueApp1.Control
{
    internal class ButtonsUI : StackLayout
    {
        public bool StutsMode = false;
        ImageButton SetIR = new ImageButton();
        Label Lbl = new Label();
        public RemoteButtonModels RemoteModels;
        Picker Data = new Picker();
        string[] ListMeunButton = 
        {
            "From Device",
            "Manual Code",
            "Delete",
        };
        public ButtonsUI(string Guid, string LayoutName)
        {
            try
            {
                Orientation = StackOrientation.Horizontal;
                RemoteModels = new RemoteButtonModels() { Guid = Guid };
                SetIR = new ImageButton()
                {
                    Source = "menuP1",
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand, 
                };
                Data = new Picker() { Title = "Menu", IsVisible = false, };
                Data.ItemsSource = ListMeunButton.ToList(); //
                Data.SelectedIndexChanged += Data_SelectedIndexChanged; // 
                SetIR.Clicked += SetIR_Clicked;

                Lbl = new Label()
                {
                    Text = LayoutName,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };
                Children.Add(Lbl);
                Children.Add(SetIR);
                Children.Add(Data);
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
                else if (Data.SelectedIndex == 0)
                {
                    FromManual();
                }
                else if (Data.SelectedIndex == 2)
                {
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
                if (StutsMode)
                {
                    return;
                }

                if (!BlueServices.IsSupportBT)
                {
                    return;
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
                    return;
                }

                string Str = await this.CurrentPage().DisplayPromptAsync("", "Add Code IR", accept: "Create", placeholder: "Typeing IR Code (Number only Or Hex Code (Add Code '0x Number')", maxLength: 40, keyboard: Keyboard.Text);

                if (!string.IsNullOrEmpty(Str))
                {


                    if (RemoteModels != null)
                    {
                        RemoteModels.Codes = Str;
                        RemoteModels.ModelRemote = "";
                        //SetIR.so = "Ok"; // 
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
 


    
    }
}
