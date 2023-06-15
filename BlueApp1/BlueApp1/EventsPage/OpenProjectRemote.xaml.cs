using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static BlueApp.EventsPage.OpenProjectRemote.ACTask;

namespace BlueApp.EventsPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OpenProjectRemote : ContentPage
	{


		//public PickerList Menu_Top;

		public OpenProjectRemote()
		{
			InitializeComponent();
			init();
			//this.Child
		}

		public OpenProjectRemote(string GuidProject)
		{
			InitializeComponent();
			init(GuidProject);
			//this.Child
		}

		//CodeElment elment;
		internal void init(string Guid = "Null")
		{
			try
			{

				if (Guid == "Null") return;

				//ItemsMagicalCode

				var MyModels = Models.Standard.Get.ProjectModel<object>.GetByProject(Guid);
				ItemsMagicalCode.Children.Clear();
				if (MyModels.Status)
				{
					var FinelProject = MyModels.Data.FirstOrDefault();
					if (FinelProject != null)
					{//FinelProject
						ProjectName.Text = FinelProject.Name;
						var MyButton = Models.Standard.Get.RemotesButton.GetByProject(FinelProject.Guid);
						if (MyButton.Count > 0)
						{
							addButtonCodes(MyButton);
						}
					}
				}
				else
				{
					this.CloesPage(new List<Type> { typeof(OpenProjectRemote) });
				}

				//Menu_Top = new PickerList();

				//HidePanel.Children.Add(Menu_Top);

				//Menu_Top.SelectedIndexChanged += Menu_Top_SelectedIndexChanged;
				//elment = CodeElment.NotFound;
				//  Menu_Top.Tital = "Menu";
			}
			catch (Exception ex)
			{
				this.SendAlert(ex.Message);
			}



			// "HelloA hmed".ConvertStringTOSQCOde();
		}

		private void addButtonCodes(List<Models.Base.RemoteButtonModels> MyButton)
		{
			foreach (var item in MyButton.ToList())
			{
				btnSandData button = new btnSandData()
				{
					Text = item.Name,
					BackgroundColor = Color.FromHex("#75AE94"),
					TextColor = Color.White,
					CornerRadius = 20,
					Data = item.Codes
				};
				button.Clicked += MagicalButtonSendingCode;
				ItemsMagicalCode.Children.Add(button);
			}
		}

		private void SelectMenu(object sender, EventArgs e)
		{
		}

		private void MagicalButtonSendingCode(object sender, EventArgs e)
		{
			//Send Code

			if (sender is btnSandData Code)
			{
				var DataReadly = Xamarin.Forms.DependencyService.Get<IBlueServices>();
				if (DataReadly.IsConnect)
				{
					DataReadly.Write(Code.Data+";");
					GifAcoine();
				}
				else
				{
					//is Not Connect
				}
			}





		}

		bool IsSendingCodes = false;

		async void GifAcoine()
		{
			try
			{
				if (!IsSendingCodes)
				{
					IsSendingCodes = true;
					await DoRunAminusons(MainGridMaige); //(GIFImageMagle); 
					IsSendingCodes = false;
				}
			}
			catch (Exception)
			{
				GIFImageMagle.Rotation = 0;
				IsSendingCodes = false;
			}
		}

		//MainGridMaige
		private async Task DoRunAminusons(View GIFImageMagleItems)
		{
			await Task.Run(async () =>
			{
				bool Top = false, Bot = false, backtoCenter = false;
				int Speed = 0;
				do
				{
					MainThread.BeginInvokeOnMainThread(() =>
					{
						GIFImageMagleItems.Rotation = Speed;
					});
					await Task.Delay(1);
					if (!Top)
					{
						if (Speed > 44) { Top = true; }
						Speed++;
						continue;
					}
					if (!Bot)
					{
						if (Speed < -44) { Bot = true; }
						Speed--;
						continue;
					}
					if (!backtoCenter && Bot & Top)
					{
						if (Speed >= 0 && Speed <= 2) { backtoCenter = true; GIFImageMagleItems.Rotation = 0; }
						Speed++;
						continue;
					}
				} while (!Top || !Bot || !backtoCenter);
			});
		}

		public class ACTask
		{
			public ACTask(Func<Task> Funcs)
			{
				this.Funcs = Funcs;
			}

			Func<Task> Funcs;

			public async void Run()
			{
				await Task.Run(Funcs);

			}


			public class btnSandData : Button
			{
				public string Data { set; get; }
				public string Title { set; get; }
			}

		}

	}
}

