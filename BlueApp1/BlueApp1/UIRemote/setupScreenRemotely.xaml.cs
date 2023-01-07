using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Models.Base;
namespace BlueApp1.UIRemote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupScreenRemotely : ContentPage
    {
        public SetupScreenRemotely()
        {
            InitializeComponent();
        }

        public SetupScreenRemotely(RemoteProjectModels ProjectModels)
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void PlusCodeInRemote(object sender, EventArgs e)
        {

        }
    }
}