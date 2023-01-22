using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BlueApp.Droid.Services
{
    [BroadcastReceiver(Enabled = true,Exported = false)]
    [IntentFilter(new[] { Android.Content.Intent.ActionMediaButton })] // Android.Media.MediaExtractor.
    public class CheckUpOrDownvalue : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
      //      string volume = intent.GetStringExtra
      //          (Android.Content.Intent.ActionMediaButton);
        }
    }
}