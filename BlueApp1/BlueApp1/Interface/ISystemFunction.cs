using System;
using System.Collections.Generic;
using System.Text;

namespace BlueApp.Interface
{
    public interface ISystemFunction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Text"></param>
        void ClassicMessage(string Text);
        void ExitApp();
        void SandSmsToWAppAsync(string message, string phoneNumberWithCountryCode);
        void OpenAppSettings();
        void SetMsg(string Message);
        string GetIDDevices();
        byte[] Capture();
        string GetHardwareButton();
    }
}
