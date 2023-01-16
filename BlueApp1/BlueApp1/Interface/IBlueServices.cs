using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueApp1
{
    public interface IBlueServices
    {
        bool IsSupportBT {  get; }
        bool IsConnect { get; }
        void Write(string name);
        List<string> Devies();
        Task<bool> Connect(string deviceName = "IRremote");

        Task<string> BluetoothListeningforOne(
            bool ConvertToString = true,
            bool AfterListeningConnect = false);

        event EventHandler<object> Reading;
        event EventHandler<object> ClosedConnecting;
    }
}
