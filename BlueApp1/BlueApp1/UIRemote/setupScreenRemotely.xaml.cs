using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Models.Base;
namespace BlueApp1.UIRemote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupScreenRemotely : ContentPage
    {
        private RemoteProjectModels ProjectModels = null;
        static IBlueServices blueServices = null;
        public SetupScreenRemotely()
        {
            InitializeComponent();
            InitializePage();
        }
        public SetupScreenRemotely(RemoteProjectModels ProjectModels)
        {
            InitializeComponent();
            this.ProjectModels = ProjectModels;
            InitializePage();
        }

        void InitializePage()
        {
            blueServices = Xamarin.Forms.DependencyService.Get<IBlueServices>();
            //ProjectModels.Guid  

        }




        public static IBlueServices BlueServices
        {
            get
            {
                if (blueServices == null)
                {
                    blueServices = Xamarin.Forms.DependencyService.Get<IBlueServices>();
                }

                return blueServices;
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void PlusCodeInRemote(object sender, EventArgs e)
        {
            //add here New Buttons 

        }

        public class ButtonsUI : StackLayout
        {
            RemoteButtonModels RemoteModels;
            public ButtonsUI(string Guid, string LayoutName)
            {
                Orientation = StackOrientation.Horizontal;
                RemoteModels = new RemoteButtonModels() { Guid = Guid };
                Button SetIR = new Button()
                {
                    Text = "Saglnes",
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };
                SetIR.Clicked += SetIR_Clicked;

                Label Lbl = new Label()
                {
                    Text = LayoutName,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };

                Children.Add(Lbl);
                Children.Add(SetIR);
            
            }


            private async void SetIR_Clicked(object sender, EventArgs e)
            {
                //Set Com To Devise BT
                //Take a new sample of the signals

                if (!BlueServices.IsSupportBT)
                {
                    return;
                }

                BlueServices.Write("Ready_TNSOTS;");

                string WaitingData = await BlueServices.BluetoothListeningforOne();

                if (!string.IsNullOrEmpty(WaitingData))
                {
                    if (RemoteModels != null)
                    {
                        RemoteModels.Codes = WaitingData;
                        RemoteModels.ModelRemote = "";
                    }
                }
            }
        }




    }
}