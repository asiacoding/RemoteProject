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
            //if (IsSystemPad)
            //{
            Models.Standard.Get.RemotesButton remotesButton = new Models.Standard.Get.RemotesButton();
            string Name = Source.ToString().Replace("File: ", "");
            Models.Base.RemoteButtonModels BinKey = remotesButton.SystemPad(Name);
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
                    bool? Re = await MainPageOwner.SendAlert("لا يوجد اي امر هنا هل تريد اضافة امر ؟", new[] { "لا", "نعم" });

                    if (Re.Value)
                    {
                        await CheckCodes(Name);
                    }
                }
            }
            //}
            //else
            //{
            //    Models.Standard.Get.RemotesButton remotesButton = new Models.Standard.Get.RemotesButton();
            //    RemoteButtonModels BinKey = remotesButton.SystemPad(PAD);
            //    if (ServicesBLUE != null)
            //    {
            //        ServicesBLUE.Write(BinKey.Codes + ";");
            //    }
            //    else
            //    {
            //        //Add New Putton
            //    }
            //}
        }

        public async Task CheckCodes(string Name)
        {
            if ((ServicesBLUE == null) || !ServicesBLUE.IsConnect)
            {
                await ServicesBLUE.Connect();
            }

            ServicesBLUE.Write("A;");
            DataRes = await ServicesBLUE.BluetoothListeningforOne(); // Fix Error Looping Button Value 0Xfffffff <<< From Hardware
            if (!string.IsNullOrEmpty(DataRes))
            {
                try
                {
                    long Code = Convert.ToInt64(DataRes);
                    if (Code > 0 && Code < 4294967295)
                    {
                        RemoteButtonModels models = new RemoteButtonModels()
                        {
                            Codes = Code.ToString(),
                            Name = Name,
                            Guid = MT.SystemGuid,
                            ModelRemote = ""
                        };
                        Models.Standard.Set.RemotesButton SetNewButton = new Models.Standard.Set.RemotesButton();
                        if (SetNewButton.Add(models))
                        {

                            bool? CheckNow = await MainPageOwner.SendAlert("هذا رائع لقد تم حفظ امر جديد هل تريد التجربه الان ؟", new[]
                            {
                                        "لا",
                                        "نعم"
                                    });

                            if (CheckNow.Value)
                            {
                                ServicesBLUE.Write(DataRes + ";");
                            }

                        }
                        else
                        {
                            MainPageOwner.SendAlert("لم تنجح العملية لسبب غير معروف حاول مرة اخرى ");
                        }
                    }
                    else
                    {
                        await CheckCodes(Name); //Looping !!!
                    }
                }
                catch (Exception)
                {
                    await CheckCodes(Name); //Looping !!!
                }
            }
            else
            {
                MainPageOwner.SendAlert("لم تنجح العملية لسبب غير معروف حاول مرة اخرى ");
            }



        }

    }
}
