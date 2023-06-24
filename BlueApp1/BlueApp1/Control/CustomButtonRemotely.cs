using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using BlueApp.Extensions;
using Models.Base;
using System.Threading.Tasks;
using BlueApp1.Interface;

namespace BlueApp.Control
{
	public class CustomButtonRemotely : ImageButton
	{
		//The process did not work for some unknown reason, try again
		private const string FilAndTryAgain = "The process did not work for some unknown reason, try again";
		private const string OperationSuccess = "This is great. A new order has been saved. Do you want to try it now ?";
		private const string OperationYes = "Yes";
		private const string OperationNo = "No";
		private const string OperationOrders = "There is no order here Do you want to add an order ?";


		//It's System Pad
		public bool IsSystemPad { set; get; } = true; // Is Main Page or Project ????? true 
		public string PAD { set; get; }
		public Page MainPageOwner { set; get; }

		//It's Normal Pad
		public string ProjectGuid { set; get; }
		public string TagProject { set; get; }
		private string DataRes { set; get; }
		public string NameCode { set; get; }

		//  private IBlueServices ServicesBLUE = null;
		private USBSerial USBSerialService = null;
		public CustomButtonRemotely()
		{
			//   ServicesBLUE = DependencyService.Get<IBlueServices>();
			USBSerialService = DependencyService.Get<USBSerial>();
			this.Clicked += CustomButtonRemotely_Clicked;


			USBSerialService.RecverData += USBSerialService_RecverData;

			BackgroundColor = Color.Transparent;
		}

		private async void USBSerialService_RecverData(object LastSenderData, string Data)
		{

			//add ac here !!!

			if (!string.IsNullOrEmpty(DataRes))
			{
				try
				{

					long Code = Convert.ToInt64(DataRes);

					RemoteButtonModels models = new RemoteButtonModels()
					{
						Codes = Code.ToString(),
						Name = NameCode,
						Guid = MT.SystemGuid,
						ModelRemote = "" // NO using Here
					};

					var AddObj = Models.Standard.Set.AddModel<RemoteButtonModels>.Add(models);

					if (AddObj)
					{
						bool? CheckNow = await MainPageOwner.SendAlert(OperationSuccess, new[]
						{
							OperationNo,
							OperationYes
						});

						if (CheckNow.Value)
						{
							//     ServicesBLUE.Write(DataRes + ";"); // Send Data To Mobile Open Reader IR
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
				catch (Exception ex)
				{
					//	await CheckCodes(Name);
					MainPageOwner.SendAlert(ex.Message);
				}
			}
			else
			{
				MainPageOwner.SendAlert(FilAndTryAgain);
			}
		}

		//لا يوجد اي امر هنا هل تريد اضافة واحد ؟


		private async void CustomButtonRemotely_Clicked(object sender, EventArgs e)
		{
			Models.Standard.Get.RemotesButton remotesButton = new Models.Standard.Get.RemotesButton();
			NameCode = Source.ToString().Replace("File: ", "");
			RemoteButtonModels BinKey = remotesButton.SystemPad(NameCode);
			if (BinKey != null)
			{

				//if (ServicesBLUE != null)
				//{
				//	ServicesBLUE.Write(BinKey.Codes + ";");
				//}
				//else
				//{
				//}


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
						CheckCodes(NameCode);
					}
					else
					{

					}
				}
				else
				{
					//Regster Main Page Object !!
				}
			}
		}

		public void CheckCodes(string Name)
		{
			//			if ((ServicesBLUE == null) || !ServicesBLUE.IsConnect) { _ = await ServicesBLUE.Connect(); }
			//			ServicesBLUE.Write("getcodes;"); // Send IR
			//			DataRes = await ServicesBLUE.BluetoothListeningforOne();
			//			Send Only !!
		}


	}
}
