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
    public partial class RemoteUI : ContentPage
    {
        private readonly IBlueServices ServicesBLUE = null;

        public RemoteUI()
        {
            InitializeComponent();
            ServicesBLUE = DependencyService.Get<IBlueServices>();

        }

   

        private void downClick(object sender, EventArgs e)
        {
            if (ServicesBLUE.IsConnect)
            {
                ServicesBLUE.Write("16749165;");
            }
        }

        private void rightClick(object sender, EventArgs e)
        {
            if (ServicesBLUE.IsConnect)
            {
                ServicesBLUE.Write("4039382595;");
            }
        }

        private void leftClick(object sender, EventArgs e)
        {
            if (ServicesBLUE.IsConnect)
            {
                ServicesBLUE.Write("16736925;");
            }
        }

        private void upClick(object sender, EventArgs e)
        {
            if (ServicesBLUE.IsConnect)
            {
                ServicesBLUE.Write("1047077;");
            }
        }

        private void ChangeMode(object sender, EventArgs e)
        {

        }
    }
}