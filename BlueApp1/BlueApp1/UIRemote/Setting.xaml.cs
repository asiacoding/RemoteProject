using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp.UIRemote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Setting : ContentPage
    {
        public Setting()
        {
            InitializeComponent();  
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
			// Is Old Test
			// StackImage1.Source = TextBox1.Text.ConvertStringTOSQCOde();
			
			//Root myDeserializedClass = JsonConvert.DeserializeObject(myJsonResponse);

			var User =  Models.Standard.Get.ProjectModel<object>.GetALI();

			if (User.Status)
			{
				var MyProject = User.Data;

				if (MyProject.Count < 1) { return; } //No Project

				var GetButtons = Models.Standard.Get.RemotesButton.GetByProject(MyProject.FirstOrDefault().Guid);
				
				if (GetButtons.Count < 1) { return; } //No Buttons

				// Object1 = InfoSending ...
				// object2 = RemoteProject Model
				// object3 =  List of Buttons Project Model
				Models.Base.StandardModel<List<string>, Models.Base.RemoteProjectModels, List<Models.Base.RemoteButtonModels>> model = new Models.Base.StandardModel<List<string>, Models.Base.RemoteProjectModels, List<Models.Base.RemoteButtonModels>>() { object1 = new List<string>(),object2 = new Models.Base.RemoteProjectModels(),object3 = new List<Models.Base.RemoteButtonModels>() };

				model.object1 = new List<string>() { "Info1" , "Info2"  };
				model.object2 = MyProject.FirstOrDefault();
				model.object3 = GetButtons;

				var StrOut = JsonConvert.SerializeObject(model);

				try
				{
					string TxEccLvl = TextBox1.Text;

					QRCodeGenerator.ECCLevel ECC = QRCodeGenerator.ECCLevel.H;
					if (TxEccLvl == "0")
					{
						ECC = QRCodeGenerator.ECCLevel.L;
					}/*
					       L = 0,
            M = 1,
            Q = 2,
            H = 3
					  */
					else if (TxEccLvl == "1"){ ECC = QRCodeGenerator.ECCLevel.M; }
					else if (TxEccLvl == "2"){ ECC = QRCodeGenerator.ECCLevel.Q; }
					else if (TxEccLvl == "3") { ECC = QRCodeGenerator.ECCLevel.H; }

					StackImage1.Source = StrOut.ConvertStringTOSQCOde(ECC, Convert.ToInt32(TextBox2.Text));
				}
				catch (Exception ex)
				{
					this.SendAlert(ex.Message);
				}


			}

		}
    }
}