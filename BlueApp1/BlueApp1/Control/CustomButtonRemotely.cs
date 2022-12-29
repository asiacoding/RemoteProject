using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using BlueApp1.Extensions;
using Models.Base;

namespace BlueApp1.Control
{
    public class CustomButtonRemotely : ImageButton
    {
        private IBlueServices ServicesBLUE = null;
        public CustomButtonRemotely()
        {
            ServicesBLUE = DependencyService.Get<IBlueServices>();
            this.Clicked += CustomButtonRemotely_Clicked;
        }

        //لا يوجد اي امر هنا هل تريد اضافة واحد ؟

        //It's System Pad
        public bool IsSystemPad { set; get; } = true;
        public string PAD { set; get; }
        public Page MainPageOwner { set; get; }
        //It's Normal Pad
        public string ProjectGuid { set; get; }
        public string TagProject { set; get; }

        private async void CustomButtonRemotely_Clicked(object sender, EventArgs e)
        {
            if (IsSystemPad)
            {
                Models.Standard.Get.RemotesButton remotesButton = new Models.Standard.Get.RemotesButton();
                var Name = this.Source.ToString().Replace("File: ", "");
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
                        //                       
                        var Re = await MainPageOwner.SandAlert("لا يوجد اي امر هنا هل تريد اضافة امر ؟", new[] { "لا", "نعم" });

                        if (Re.Value)
                        {
                            ServicesBLUE.Write("A;");
                            var Get = await ServicesBLUE.BluetoothListeningforOne(); // Fix Error Looping Button Value 0Xfffffff <<< From Hardware
                            if (!string.IsNullOrEmpty(Get))
                            {
                                RemoteButtonModels models = new RemoteButtonModels()
                                {
                                    Codes = Get,
                                    Name = Name,
                                    Guid = MT.SystemGuid,
                                    ModelRemote = ""
                                };
                                Models.Standard.Set.RemotesButton SetNewButton = new Models.Standard.Set.RemotesButton();
                                if (SetNewButton.Add(models))
                                {
                                    var CheckNow = await MainPageOwner.SandAlert("هذا رائع لقد تم حفظ امر جديد هل تريد التجربه الان ؟", new[] { "لا", "نعم" });

                                    if (CheckNow.Value)
                                    {
                                        ServicesBLUE.Write(Get + ";");
                                    }
                                }
                                else
                                {
                                    //Add Code 
                                }
                            }
                            else
                            {
                                MainPageOwner.SandAlert("لم تنجح العملية لسبب غير معروف حاول مرة اخرى ");
                            }
                        }
                    }
                }
            }
            else
            {
                Models.Standard.Get.RemotesButton remotesButton = new Models.Standard.Get.RemotesButton();
                Models.Base.RemoteButtonModels BinKey = remotesButton.SystemPad(PAD);
                if (ServicesBLUE != null)
                {
                    ServicesBLUE.Write(BinKey.Codes + ";");
                }
                else
                {
                    //Add New Putton
                }
            }
        }

    }
}
