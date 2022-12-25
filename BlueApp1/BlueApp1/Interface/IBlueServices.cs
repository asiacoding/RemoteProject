using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueApp1
{
    public interface IBlueServices
    {
        void Connect(string deviceName = "IRremote");
        void Read();
        void Write(string name);
        
        List<string> Devies();
        
        bool IsConnect { get; }

        event EventHandler<object> Reading;
        event EventHandler<object> ClosedConnecting;

        Task<string> BluetoothListeningforOne(bool ConvertToString = true);
    }
}
