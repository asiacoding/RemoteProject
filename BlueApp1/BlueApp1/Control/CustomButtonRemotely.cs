using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BlueApp1.Extensions;
using Models.Base;
using System.Threading.Tasks;

namespace BlueApp1.Control
{
    public class CustomButtonRemotely : ImageButton
    {
        string FilAndTryAgain = "The process did not work for some unknown reason, try again"; //The process did not work for some unknown reason, try again
        string OperationSuccess = "This is great. A new order has been saved. Do you want to try it now ?";
        string OperationYes = "Yes";
        string OperationNo = "No";
        string OperationOrders = "There is no order here Do you want to add an order?";

        private IBlueServices ServicesBLUE = null;
        public CustomButtonRemotely()
        {
            ServicesBLUE = DependencyService.Get<IBlueServices>();
            this.Clicked += CustomButtonRemotely_Clicked;
            BackgroundColor = Color.Transparent;
        }

        //لا يوجد اي امر هنا هل تريد اضافة واحد ؟

        //It's System Pad
        public bool IsSystemPad { set; get; } = true;
        public string PAD { set; get; }
        public Page MainPageOwner { set; get; }
        //It's Normal Pad
        public string ProjectGuid { set; get; }
        public string TagProject { set; get; }
        private string DataRes { set; get; }
        private async void CustomButtonRemotely_Clicked(object sender, EventArgs e)
        {
            Models.Standard.Get.RemotesButton remotesButton = new Models.Standard.Get.RemotesButton();
            string Name = Source.ToString().Replace("File: ", "");
            RemoteButtonModels BinKey = remotesButton.SystemPad(Name);
            if (BinKey != null)
            {
                if (ServicesBLUE != null)
                {
                    ServicesBLUE.Write(BinKey.Codes + ";");
                }
                else
                {
                }
            }
            else
            {
                if (MainPageOwner != null)
                {
                    //There is no order here Do you want to add an order?
                    //لا يوجد اي امر هنا هل تريد اضافة امر ؟
                    bool? Re = await MainPageOwner.SendAlert(OperationOrders, new[]
                    {
                        OperationNo,
                        OperationYes
                    });

                    if (Re.Value)
                    {
                        await CheckCodes(Name);
                    }
                }
            }
        }

        public async Task CheckCodes(string Name)
        {
            if ((ServicesBLUE == null) || !ServicesBLUE.IsConnect) { _ = await ServicesBLUE.Connect(); }
            ServicesBLUE.Write("GetCodes;"); // Send IR
            DataRes = await ServicesBLUE.BluetoothListeningforOne();
            if (!string.IsNullOrEmpty(DataRes))
            {
                try
                {
                    long Code = Convert.ToInt64(DataRes);
                    RemoteButtonModels models = new RemoteButtonModels()
                    {
                        Codes = Code.ToString(),
                        Name = Name,
                        Guid = MT.SystemGuid,
                        ModelRemote = "" // NO using Here
                    };
                    Models.Standard.Set.RemotesButton SetNewButton = new Models.Standard.Set.RemotesButton();
                    if (SetNewButton.Add(models))
                    {
                        bool? CheckNow = await MainPageOwner.SendAlert(OperationSuccess, new[]
                        {
                            OperationNo,
                            OperationYes
                        });

                        if (CheckNow.Value)
                        {
                            ServicesBLUE.Write(DataRes + ";"); // Send Data To Mobile Open Reader IR
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        MainPageOwner.SendAlert(FilAndTryAgain);
                    }
                }
                catch (Exception)
                {
                    await CheckCodes(Name);
                }
            }
            else
            {
                MainPageOwner.SendAlert(FilAndTryAgain);
            }



        }

    }
}
