using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp1.Control.EditRemotely
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScreenEditing : ContentView
    {
        View TargetView;

        public ScreenEditing()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
        }

        private void TargetObjecting(object sender, EventArgs e)
        {
            if (sender is View SetView)
                TargetView = SetView;
        }




        void MoveObject(string MoveStr)
        {
            if (TargetView != null)
            {
                var Reg = AbsoluteLayout.GetLayoutBounds(TargetView);
                switch (MoveStr)
                {
                    case "<":
                        Reg.Left -= 10;
                        break;
                    case ">":
                        Reg.Left += 10;
                        break;
                    case "v":
                        Reg.Top += 10;
                        break;
                    case "^":
                        Reg.Top -= 10;
                        break;
                }
                AbsoluteLayout.SetLayoutBounds(TargetView, Reg);
            }
        }

        

        private void LeftPoint(object sender, EventArgs e)
        {
            MoveObject("<");
        }
        private void DownPoint(object sender, EventArgs e)
        {
            MoveObject("v");
        }
        private void RightPoint(object sender, EventArgs e)
        {
            MoveObject(">");
        }
        private void UpsPoint(object sender, EventArgs e)
        {
            MoveObject("^");
        }
 
    }
}