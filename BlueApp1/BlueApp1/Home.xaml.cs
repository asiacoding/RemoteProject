using BlueApp.EventsPage;
using BlueApp.Interface;
using BlueApp.UIRemote;
using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{

		public const string TargetObject = "T"; // no Remove This

		private static IBlueServices ServicesBLUE = null;
		public Home()
		{
			InitializeComponent();
			//BindingContext = new BlueApp.Language.DataModels.MVVMHomeModels();
			if (ServicesBLUE == null) { ServicesBLUE = DependencyService.Get<IBlueServices>(); } // In Start App . Connect BT Def 
			RefLayoutConnectToBT();
			//MessagingCenter.Subscribe<string, string>(TargetObject, "SentToHomePage", (snd, arg) => { Device.BeginInvokeOnMainThread(() => { this.SendAlert(arg); }); });
		}


		private async void opneControl(object sender, EventArgs e)
		{
			try
			{
				if (ServicesBLUE.IsConnect)
				{
					this.GOTO(TO: new RemoteUI());
				}
				else
				{
					string action = await DisplayActionSheet("You are not connected to a device now, do you want to connect ?", "cancel", null, "Connect", "Back", "skip");

					if (action == "Connect")
					{
						_ = await ServicesBLUE.Connect();
						RefLayoutConnectToBT();
					}
					else if (action == "skip")
					{
						this.GOTO(TO: new RemoteUI());
					}
				}
			}
			catch (Exception ex)
			{
				Notes.Text = ex.Message;
			}
		}
		private void RefLayoutConnectToBT()
		{
			if (ServicesBLUE == null)
			{

				ConnectBtn.Text = "Connect";

				Notes.Text = "";

				return;

			}

			Notes.Text = ServicesBLUE.IsConnect ? "The connection has been restored successfully" : "An error occurred, please try again";
			ConnectBtn.Text = ServicesBLUE.IsConnect ? "Connected" : "Connect";
		}
		private async void Checkconnect(object sender, EventArgs e)
		{
			try
			{

				bool CheckConnecting = await ServicesBLUE.Connect();
				Notes.Text = CheckConnecting ?
					"A device has been connected" :
					"An error occurred, please try again";

				// Set Disconnect Bluehoots if Connect Blueth..


				ConnectBtn.Text = CheckConnecting ?
					"Connected" :
					"Try again";




			}
			catch (Exception ex)
			{
				this.SendAlert(ex.Message);
			}
		}


		private void AddNewProject(object sender, EventArgs e)
		{
			this.GOTO(TO: new AddingNewProject());
		}
		private async void ExitAppClick(object sender, EventArgs e)
		{
			try
			{
				bool? exitapp = await this.SendAlert(M: "Do you want out ?", Questions: new[] { "no", "yes" });

				if (exitapp == true)
				{
					ISystemFunction MySetting = DependencyService.Get<ISystemFunction>();
					MySetting.ExitApp();
				}
			}
			catch (Exception)
			{
			}
		}
		private void SettingPages(object sender, EventArgs e)
		{
			this.GOTO(new Setting());
		}

		private void GotoPageProjects(object sender, EventArgs e) //Do Selecting Item from Piker1
		{
			try
			{

				int SelectIndex = Piker1.SelectedIndex;


				if (SelectIndex == -1) return;

				if (CurrentProject.Count + 1 >= SelectIndex)
				{
					var MyObject = CurrentProject[SelectIndex];

					if (MyObject is RemoteProjectModels GetProject)
					{
						this.GOTO(new OpenProjectRemote(GetProject.Guid));
					}

				}
			}
			catch (Exception)
			{
			}
		}
		List<string> ProjectManger = new List<string>();
		List<RemoteProjectModels> CurrentProject = new List<RemoteProjectModels>();
		private void GetDataFromUart(object sender, EventArgs e)
		{
			//    Models.Standard.Delete.RemotesButton DeleteObjRemote = new Models.Standard.Delete.RemotesButton();
			//    DeleteObjRemote.DeleteAll("1234");//Save Codes
			try
			{
				var MyRespones = Models.Standard.Get.ProjectModel<object>.GetALI();

				if (MyRespones.Status)
				{
					ProjectManger = new List<string>();
					MyRespones.Data.ForEach((a) => { ProjectManger.Add(a.Name); }); // Set Name 
					CurrentProject = MyRespones.Data;
					Piker1.ItemsSource = ProjectManger;
					Piker1.Focus();
				}
				else
				{
					//Add Msg
				}
			}
			catch (Exception)
			{

			}
		}

		private async void EnterCode(object sender, EventArgs e)
		{
			try
			{
				var cmd = Xamarin.Forms.DependencyService.Get<IBlueServices>();

				if (!cmd.IsSupportBT)
				{
					DisplayAlert("", "Blue is Not Suppoert in This Devices", "back");
				}

				if (cmd.IsConnect)
				{

					cmd.Write(Xenters.Text.Replace(";;", ";"));

					if (Xenters.Text.Contains(";;"))
					{
						RetrunCode.Text = await cmd.BluetoothListeningforOne();
					}

				}
				else
				{
					_ = DisplayAlert("", "The  Blue is Disconnect ", "back");
				}

			}
			catch (Exception ex)
			{
				_ = DisplayAlert("", ex.Message, "back");
			}
		}
	}

}

//Titla Lbl
//Control panels
//new project
//setting
//Delete existing remotes
//Exit