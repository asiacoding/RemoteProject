using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using BlueApp1.Droid.Services;

[assembly: Dependency(typeof(DS_SystemFunction))]
namespace BlueApp1.Droid.Services
{

    public class DS_SystemFunction : Interface.ISystemFunction
    {

        Activity ContextActivitys = (Activity)Forms.Context;

        public void ClassicMessage(string Text) //XXXXXXXXXxxxxxx....
        {
            //ContextWrapper.BaseContext
            Toast.MakeText(MainActivity.MainActivitY, Text+";", ToastLength.Short);
            Toast.MakeText(MainActivity.MainActivitY.ApplicationContext, Text+";", ToastLength.Short);
            Toast.MakeText(ContextActivitys, Text+";", ToastLength.Short);
        }
    }
}