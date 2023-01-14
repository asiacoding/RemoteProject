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
using BlueApp1;
using Android.Bluetooth;
using System.Threading.Tasks;
using Java.Util;
using BlueApp1.Droid;
using System.Threading;
using Java.IO;

[assembly: Xamarin.Forms.Dependency(typeof(BlueServices))]
namespace BlueApp1.Droid
{
    class BlueServices : IBlueServices
    {
        private UUID uuid =
            UUID.FromString("00001101-0000-1000-8000-00805f9b34fb");

        private readonly BluetoothAdapter adapter;

        private BluetoothSocket _Socket;

        public bool IsConnect => _Socket != null && _Socket.IsConnected; //Check Connect BT in Device

        public bool IsSupportBT => adapter != null && adapter.IsEnabled;

        public event EventHandler<object> Reading;//Buffer,ResordString

        private BluetoothDevice device;

        public event EventHandler<object> ClosedConnecting;

        public BlueServices()
        {
            try
            {
                adapter = BluetoothAdapter.DefaultAdapter; // in Start App Open And Connect Default BT

                if (adapter != null) // Check is null
                {
                    if (!adapter.IsEnabled)
                    {
                        adapter.Enable();
                    }

                    _ = Connect(); // call Conenct ..
                }
                else
                {
                    // add Coding Here !!
                }
            }
            catch (Exception)
            {
            }
        }


        public List<string> Devies()
        {
            try
            {
                //No Support BT
                if (adapter == null) return null;

                List<string> mystr = new List<string>();
                foreach (var item in BluetoothAdapter.DefaultAdapter.BondedDevices) // Get All Name BT chronic in Device
                {
                    mystr.Add(item.Name);
                }
                return mystr;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Connect(string deviceName = "IRremote")
        {
            try
            {
                if (_Socket != null) // Check _Socket is init or Null Value ?
                {
                    _Socket.Close(); // Closed Object in Start / Restart Object ..
                }

                device = (from bd in adapter.BondedDevices // Check IRremote Name in Device or More name ....
                          where bd.Name == deviceName
                          select bd).FirstOrDefault();

                if ((int)Android.OS.Build.VERSION.SdkInt >= 10) // <----- Check this Fun if SDK Number => 10 Ver or no ?
                {
                    _Socket = device.CreateInsecureRfcommSocketToServiceRecord(uuid); // <----- Connect this Fun if SDK Number => 10 Ver
                }
                else
                {
                    _Socket = device.CreateRfcommSocketToServiceRecord(uuid); // <---------  then < 10 Call This 
                }

                await _Socket.ConnectAsync(); // Connect BT Console

                return _Socket.IsConnected; // Check

            }
            catch (Exception)
            {
                return false;
            }
        }



        public async void ClaerBuffer()
        {
            await BluetoothListeningforOne(true);
        }



        public async void Write(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name)) return; // Check Str Name 
                if (_Socket == null) { return; } // Check Socket is Null ?
                if (!_Socket.IsConnected) // Check Device is Connect or no ?
                {
                    bool CheckSocket = await this.Connect(); // Connect Device
                    if (!CheckSocket) return; // then Fil Connect Out Method 
                }
                byte[] buffer = Encoding.ASCII.GetBytes(name); // Convert Normal String to Number Code (Encoding ASCII)
                await _Socket.OutputStream.WriteAsync(buffer, 0, buffer.Length); //Send Buffer to Bluthooht Device
            }
            catch (Exception)
            {
                //ex.Message = "";
            }
        }

        //public async void Read()
        //{
        //    try
        //    {
        //        if (_Socket == null || !IsConnect)
        //        {
        //            if (ClosedConnecting != null)
        //                ClosedConnecting.Invoke(this, "No conenct App");
        //            return;
        //        }
        //        string string1 = "";
        //        byte[] buffer = new byte[254];
        //        bool OutOfMainBlock = false;
        //        _Socket.Connect();
        //        while (_Socket.IsConnected)
        //        {
        //            await _Socket.InputStream.ReadAsync(buffer, 0, buffer.Length);
        //            foreach (byte item in buffer)
        //            {
        //                char Output = Convert.ToChar(item);
        //                if (Output == ';' || Output == '\0' || Output == 59)
        //                {
        //                    OutOfMainBlock = true;
        //                    break;
        //                }
        //                string1 += Output;
        //            }
        //            if (OutOfMainBlock)
        //            {
        //                //Toast.MakeText(MainActivity.MainActivitY, string1, ToastLength.Long);
        //                if (Reading != null) { Reading.Invoke(buffer, string1); }
        //                OutOfMainBlock = false;
        //                _Socket.Close();
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        public async Task<string> BluetoothListeningforOne(bool ConvertToString = true)
        {
            try
            {
                #region Check Connect is Acdvble or Disconnect
                if (_Socket == null)
                {
                    if (ClosedConnecting != null) ClosedConnecting.Invoke(this, "No conenct App");
                    return null;
                }

                if (!IsConnect)
                {
                    bool GetAnw = await Connect();
                    if (!GetAnw)
                        return null;
                }
                #endregion

                #region Data
                string Data = "";
                byte[] buffer = new byte[254];
                bool OutOfMainBlock = false;
                #endregion

                while (_Socket.IsConnected)
                {
                    _ = await _Socket.InputStream.ReadAsync(buffer, 0, buffer.Length);

                    foreach (byte item in buffer)
                    {
                        string Output = ConvertToString ? Convert.ToChar(item).ToString() : item.ToString();
                        //NullNULLNULL
                        //in AcsII '59' = ';'
                        if (Output == ";" || Output == "\0" || item == 59)
                        {
                            OutOfMainBlock = true;
                            break;
                        }

                        Data += Output;
                    }

                    if (string.IsNullOrEmpty(Data))
                    {
                        continue;
                    }

                    if (OutOfMainBlock)
                    {
                        break;
                    }

                }

                if (_Socket.IsConnected) { _Socket.Close(); }

                return Data;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}