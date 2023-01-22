using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Speech;
using System.Collections.Generic;
using System;
using  BlueApp.interface_enum;
using Xamarin.Forms;
using SpeechToText;


[assembly: Dependency(typeof(TextToSpace))]
namespace SpeechToText
{
    public class TextToSpace : ISpeechToText
    {
        public bool CheckPackageMicroPhones()
        {
            string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
            if (rec != "android.hardware.microphone")
            {
                return false;
            }
            return true;
        }
        public void StartSpeechToText()
        {
            StartRecordingAndRecognizing();
        }

        private bool isRecording;
        private readonly int VOICE = 10;
        public void StartRecordingAndRecognizing()
        {

            if (!CheckPackageMicroPhones())
            {
                return;
            }



            // create the intent and start the activity
            var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            // put a message on the modal dialog
            voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "SpackNow");
            // if there is more then 1.5s of silence, consider the speech over
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
            voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
            // you can specify other languages recognised here, for example
            // voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.German);
            // if you wish it to recognise the default Locale language and German
            // if you do use another locale, regional dialects may not be recognised very well
            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
            BlueApp.Droid.MainActivity.MainActivitY.StartActivityForResult(voiceIntent, VOICE);

        }




        public void StopSpeechToText()
        {

        }

        //public class SpeechToTextImplementation //: ISpeechToText
        //{
        //    private readonly int VOICE = 10;
        //    private Activity _activity;
        //    public SpeechToTextImplementation()
        //    {
        //        var activity = BlueApp1.Droid.MainActivity.MainActivitY;
        //        _activity = activity;

        //    }

        //    public void StartSpeechToText()
        //    {
        //        StartRecordingAndRecognizing();
        //    }

        //    private void StartRecordingAndRecognizing()
        //    {
        //        string rec = global::Android.Content.PM.PackageManager.FeatureMicrophone;
        //        if (rec == "android.hardware.microphone")
        //        {
        //            try
        //            {
        //                var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
        //                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
        //                voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Speak now");
        //                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 3000000);
        //                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 3000000);
        //                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 3000000);
        //                voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
        //                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
        //                _activity.StartActivityForResult(voiceIntent, VOICE);

        //            }
        //            catch
        //            {
        //                String appPackageName = "com.google.android.googlequicksearchbox";
        //                try
        //                {
        //                    Intent intent = new Intent(Intent.ActionView, global::Android.Net.Uri.Parse("market://details?id=" + appPackageName));
        //                    _activity.StartActivityForResult(intent, VOICE);

        //                }
        //                catch
        //                {
        //                    Intent intent = new Intent(Intent.ActionView, global::Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=" + appPackageName));
        //                    _activity.StartActivityForResult(intent, VOICE);
        //                }
        //            }

        //        }
        //        else
        //        {
        //            throw new Exception("No mic found");
        //        }
        //    }


        //    public void StopSpeechToText()
        //    {

        //    }




        //}


    }
}



