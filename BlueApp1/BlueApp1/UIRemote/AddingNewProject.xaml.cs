using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            User = null;
        }
        static RemoteProjectModels User = null;
        private void NextSatp(object sender, EventArgs e)
        {

            if (User == null)
                User = new RemoteProjectModels()
                {
                    Name = txtNameControl.Text,
                    Guid = Guid.NewGuid().ToString(),
                    Description = txtDesciptionsControl.Text,
                    Category = txtCategoryRemotes.Text,
                    SizeButton = picker.SelectedIndex,
                };

            if (!string.IsNullOrEmpty(txtNameControl.Text) && picker.SelectedIndex != 0)
            {
                this.GOTO(new SetupScreenRemotely(User));
            }
            else
            {
                this.SendAlert("Please fill in all required information");
            }
        }



    }
}