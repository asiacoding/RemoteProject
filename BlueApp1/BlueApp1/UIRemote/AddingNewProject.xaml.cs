using Models.Base;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp1.UIRemote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddingNewProject : ContentPage
    {
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
                    SizeButton = picker.SelectedIndex,
                };
            }

            if (!string.IsNullOrEmpty(txtNameControl.Text) && picker.SelectedIndex != 0)
            {
                this.GOTO(new SetupScreenRemotely(RemoteModeling));
            }
            else
            {
                this.SendAlert("Please fill in all required information");
            }

        }



    }
}