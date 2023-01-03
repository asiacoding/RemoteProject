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
    internal class BlueServices : IBlueServices
    {

        UUID uuid = UUID.FromString("00001101-0000-1000-8000-00805f9b34fb");

        BluetoothAdapter adapter;

        BluetoothSocket _Socket;

        public bool IsConnect => _IsConnect;

        public bool _IsConnect
        {
            get
            {
                if (_Socket == null) return false; else return _Socket.IsConnected;
            }
        }

        public event EventHandler<object> Reading;//Buffer,ResordString
        BluetoothDevice device;

        public event EventHandler<object> ClosedConnecting;

        public BlueServices()
        {
            adapter = BluetoothAdapter.DefaultAdapter;

            if (!adapter.IsEnabled)
            {
                adapter.Enable();
            }

            Connect();
        }


        public List<string> Devies()
        {
            try
            {
                List<string> mystr = new List<string>();
                foreach (var item in BluetoothAdapter.DefaultAdapter.BondedDevices)
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

        public async void Connect(string deviceName = "IRremote")
        {
            try
            {
                if ((_Socket != null) && _Socket.IsConnected)
                {
                    return;
                }

                device = (from bd in adapter.BondedDevices
                          where bd.Name == deviceName
                          select bd).FirstOrDefault();

                if ((int)Android.OS.Build.VERSION.SdkInt >= 10) // Gingerbread 2.3.3 2.3.4
                {
                    _Socket = device.CreateInsecureRfcommSocketToServiceRecord(uuid);
                }
                else
                {
                    _Socket = device.CreateRfcommSocketToServiceRecord(uuid);
                }

                await _Socket.ConnectAsync();

             //   _IsConnect = _Socket.IsConnected;



            }
            catch (Exception ex)
            {
                try
                {
                    if (ClosedConnecting != null)
                        ClosedConnecting.Invoke(this, null);

                    if ((_Socket != null) && _Socket.IsConnected)
                    {
                        _Socket.Close();
                    }
                }
                catch (Exception ex2)
                {
                    Toast.MakeText(MainActivity.MainActivitY, ex2.Message, ToastLength.Long);
                }
             //   _IsConnect = false;
                _ = Toast.MakeText(MainActivity.MainActivitY.ApplicationContext, ex.Message, ToastLength.Long);
            }
        }


        public async void Read()
        {
            try
            {
                if (_Socket == null || !_IsConnect)
                {

                    if (ClosedConnecting != null)
                        ClosedConnecting.Invoke(this, "No conenct App");
                    return;
                }
                string string1 = "";
                byte[] buffer = new byte[254];
                bool OutOfMainBlock = false;
                while (_Socket.IsConnected)
                {
                    await _Socket.InputStream.ReadAsync(buffer, 0, buffer.Length);
                    foreach (byte item in buffer)
                    {
                        char Output = Convert.ToChar(item);
                        if (Output == ';' || Output == '\0')
                        {
                            OutOfMainBlock = true;
                            break;
                        }
                        string1 += Output;
                    }

                    if (OutOfMainBlock)
                    {
                        //Toast.MakeText(MainActivity.MainActivitY, string1, ToastLength.Long);
                        if (Reading != null) { Reading.Invoke(buffer, string1); }
                        OutOfMainBlock = false;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public async void Write(string name)
        {
            try
            {
                if ((_Socket == null) || !_Socket.IsConnected) { return; }
                byte[] buffer = Encoding.ASCII.GetBytes(name);
                await _Socket.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                //ex.Message = "";
            }
        }

        public async void ClaerBuffer()
        {
            await BluetoothListeningforOne(true);
        }

        public async Task<string> BluetoothListeningforOne(bool ConvertToString = true)
        {
            try
            {
                #region Check Connect is Acdvble or Disconnect
                if ((_Socket == null) || !_Socket.IsConnected)
                {
                    if (ClosedConnecting != null) ClosedConnecting.Invoke(this, "No conenct App");
                    return null;
                }
                #endregion
                
                #region Data
                string Data = "";
                byte[] buffer = new byte[50];
                bool OutOfMainBlock = false;
                #endregion

                while (_Socket.IsConnected)
                {
                    _ = await _Socket.InputStream.ReadAsync(buffer, 0, buffer.Length);
  
                    foreach (byte item in buffer)
                    {
                        string Output = ConvertToString ? Convert.ToChar(item).ToString() : item.ToString();

                        if (Output == ";" || Output == "\0" || item == 59)
                        {
                            OutOfMainBlock = true;
                            break;
                        }

                        Data += Output;
                    }

                    if (string.IsNullOrEmpty(Data))
                    {
                        buffer = new byte[50];
                        continue;
                    }
                    
                    if (OutOfMainBlock)
                    {
                        break;
                    }
                }

                return Data;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}