﻿using System;
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
        }

        private void NextSatp(object sender, EventArgs e)
        {
            this.GOTO(new UIRemote.setupScreenRemotely());
        }
    }
}