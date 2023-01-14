using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueApp1
{
    public interface IBlueServices
    {
        bool IsSupportBT {  get; }
        Task<bool> Connect(string deviceName = "IRremote");
        void Write(string name);
        List<string> Devies();
        bool IsConnect { get; }
        event EventHandler<object> Reading;
        event EventHandler<object> ClosedConnecting;
        Task<string> BluetoothListeningforOne(bool ConvertToString = true);
    }
}
