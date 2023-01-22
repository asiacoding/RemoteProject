using Models.Base;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp.UIRemote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddingNewProject : ContentPage
    {
        string requiredAllData = "Please fill in all required information";
        public AddingNewProject()
        {
            InitializeComponent();
            RemoteModeling = null;
        }

        static RemoteProjectModels RemoteModeling = null;
        
        private void NextSatp(object sender, EventArgs e)
        {
            if (RemoteModeling == null)
            {
                RemoteModeling = new RemoteProjectModels()
                {
                    Name = txtNameControl.Text,
                    Guid = Guid.NewGuid().ToString(),
                    Description = txtDesciptionsControl.Text,
                    Category = txtCategoryRemotes.Text,
                 //   SizeButton = picker.SelectedIndex,
                };
            }

            if (!string.IsNullOrEmpty(txtNameControl.Text))
            {
                this.GOTO(new SetupScreenRemotely(RemoteModeling));
            }
            else
            {
                this.SendAlert(requiredAllData);
            }

        }



    }
}