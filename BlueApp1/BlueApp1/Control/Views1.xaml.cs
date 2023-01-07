using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueApp1.Control
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Views1 : ContentView
    {
        public Views1()
        {
            InitializeComponent();
        }

        public string Text { set => btnDownText.Text = value; get => btnDownText.Text; }

        public ImageSource Image { set => ImgImageingControl.Source = value; get => ImgImageingControl.Source; }

        public event EventHandler<EventArgs> ClickedControl;

        private void ClickEventEnterButton(object sender, EventArgs e)
        {
            if (ClickedControl != null)
                ClickedControl.Invoke(this, e);
        }
    }
}