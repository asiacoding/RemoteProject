using BlueApp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BlueApp.interface_enum
{

    public interface ISpeechToText
    {
        void StartSpeechToText();
    }
    public interface IMessageSender
    {
    }



    public class SpeechToText
    {
        public void Start()
        {
            try
            {
                _speechRecongnitionInstance.StartSpeechToText();
            }
            catch (Exception ex)
            {
                ex.InitException();
                log += "\n" + "Not Registered";
            }
        }

      

        private readonly ISpeechToText _speechRecongnitionInstance;

        public SpeechToText()
        {

            try
            {
                _speechRecongnitionInstance = DependencyService.Get<ISpeechToText>();
            }
            catch (Exception ex)
            {
                //Mirophone.Text = ex.Message;
                ex.InitException();
                log += "\n" + ex.Message;
            }

            MessagingCenter.Subscribe<ISpeechToText, string>(this, "STT", (sender, args) =>
            {
                AddRes(args);
            });

            MessagingCenter.Subscribe<ISpeechToText>(this, "Final", (sender) =>
            {
                //Itmes.IsEnabled = true;
            });

            MessagingCenter.Subscribe<IMessageSender, string>(this, "STT", (sender, args) =>
            {
                AddRes(args);
            });


        }

        public SpeechToText(IMessageSenderDoWork.EventHandler IGotTheText)
        {

            try
            {

                this.IGotTheText = IGotTheText;
                _speechRecongnitionInstance = DependencyService.Get<ISpeechToText>();
            }
            catch (Exception ex)
            {
                //Mirophone.Text = ex.Message;
                ex.InitException();
                log += "\n" + ex.Message;
            }

            MessagingCenter.Subscribe<ISpeechToText, string>(this, "STT", (sender, args) =>
            {
                AddRes(args);
            });

            MessagingCenter.Subscribe<ISpeechToText>(this, "Final", (sender) =>
            {
                //Itmes.IsEnabled = true;
            });

            MessagingCenter.Subscribe<IMessageSender, string>(this, "STT", (sender, args) =>
            {
                AddRes(args);
            });
        }
        private void AddRes(string a)
        {
            if (IGotTheText != null)
            {
                IGotTheText(a, log);
            }
            else
            {
                log += "\n" + "Not Registered";
            }
        }
        public string log { set; get; }
        public event IMessageSenderDoWork.EventHandler IGotTheText;
    }

    public class IMessageSenderDoWork
    {
        public delegate void EventHandler(string Res, string log);
    }
}
