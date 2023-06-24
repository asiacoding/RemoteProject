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
using BlueApp1.Droid;
using Android.Hardware.Usb;
using BlueApp.Droid;
using Hoho.Android.UsbSerial.Driver;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(SerialService))]
namespace BlueApp1.Droid
{
	public class SerialService : BlueApp1.Interface.USBSerial
	{
		public const int WRITE_WAIT_MILLIS = 2000;
		public const int READ_WAIT_MILLIS = 2000;

		public static IUsbSerialPort _MainConnect;

		public event EventHandler<string> RecverData;

		public string HotLine { private set; get; }

		public IUsbSerialPort MainConnect
		{
			get
			{
				if (_MainConnect == null)
				{
					_MainConnect = initPort();
				}


				return _MainConnect;
			}
		}

		public string ListSendData { get; set; }

		public IUsbSerialPort initPort()
		{
			UsbManager manager = (Android.Hardware.Usb.UsbManager)MainActivity.MainActivitY.GetSystemService(Context.UsbService);
		 
			var availableDrivers = FindAllDriversAsync(manager);  
			if (availableDrivers == null)
			{
				HotLine = "Not Get Divers";

				return null;
			}
			var driver = availableDrivers.FirstOrDefault();

			 
			UsbDeviceConnection connection = manager.OpenDevice(driver.Device); 
			if (connection == null)
			{
				HotLine = "Not Get Connection";
				return null;
			}
			var port = driver.Ports[0];//.getPorts().get(0); // Most devices have just one port (port 0)
			port.Open(connection);
			port.SetParameters(9600, 8, StopBits.One, Parity.None);
			HotLine = "Ok to End";
			return port;
		}

		public List<string> GetList()
		{

			//	var Points = (Android.Hardware.Usb.UsbEndpoint)MainActivity.MainActivitY.GetSystemService(Context.);
			UsbManager manager = (Android.Hardware.Usb.UsbManager)MainActivity.MainActivitY.GetSystemService(Context.UsbService);
			var table = UsbSerialProber.DefaultProber;
			var listdir = table.FindAllDrivers(manager).ToList();

			var data = manager.DeviceList.FirstOrDefault(device => device.Value.VendorId == 6790 && device.Value.ProductId == 29987);



			List<string> items = new List<string>();

			items.Add(data.Key);

			items.Add($@"
VendorId		   :  {data.Value.VendorId}
SerialNumber	   :  {data.Value.SerialNumber}
ProductName		   :  {data.Value.ProductName}
ProductId		   :  {data.Value.ProductId}
ManufacturerName   :  {data.Value.ManufacturerName}
InterfaceCount	   :  {data.Value.InterfaceCount}
DeviceProtocol	   :  {data.Value.DeviceProtocol}	
DeviceName		   :  {data.Value.DeviceName}
DeviceId		   :  {data.Value.DeviceId}
ConfigurationCount :  {data.Value.ConfigurationCount}
Version            :  {data.Value.Version}
");




			return items;
		}

		internal static List<IUsbSerialDriver> FindAllDriversAsync(UsbManager usbManager)
		{
			// using the default probe table
			// return UsbSerialProber.DefaultProber.FindAllDriversAsync (usbManager);
			// adding a custom driver to the default probe table
			//var table = UsbSerialProber.DefaultProbeTable;
			//table.AddProduct(0x1b4f, 0x0008, table.Class); // IOIO OTG
			//table.AddProduct(0x09D8, 0x0420, table.Class); // Elatec TWN4
			//table.AddProduct(0x1A86, 0x7523, table.Class); // Elatec TWN4
			////	table.AddProduct(6790, 29987, table.Class); // Elatec TWN4
			var prober = UsbSerialProber.DefaultProber; 
			var Set = prober.FindAllDrivers(usbManager).ToList();
			return Set;
		}




		public string Get(int WaitReaderData = SerialService.WRITE_WAIT_MILLIS, bool ConvertToString = true)
		{
			try
			{
				if (MainConnect == null)
				{
					return null;
				}


				#region Data
				string Data = "";
				byte[] buffer = new byte[8192];
				//	bool OutOfMainBlock = false;
				#endregion

				int len = MainConnect.Read(buffer, READ_WAIT_MILLIS);
				foreach (var item in buffer)
				{
					string Output = ConvertToString ? Convert.ToChar(item).ToString() : item.ToString();
					if (Output == ";" || Output == "\0" || item == 59)
					{

						break;
					}
					Data += Output;
				}

				//_ = await _Socket.InputStream.ReadAsync(buffer, 0, buffer.Length);
				//
				//foreach (byte item in buffer)
				//{
				//	string Output = ConvertToString ? Convert.ToChar(item).ToString() : item.ToString();
				//
				//	//in AcsII '59' = ';'
				//	if (Output == ";" || Output == "\0" || item == 59)
				//	{
				//		OutOfMainBlock = true;
				//		break;
				//	}
				//
				//	Data += Output;
				//} 
				/*
								 byte[] buffer = Encoding.ASCII.GetBytes(name); // Convert Normal String to Number Code (Encoding ASCII)
							   await _Socket.OutputStream.WriteAsync(buffer, 0, buffer.Length); //Send Buffer to Bluthooht Device
				 */

				return Data;
			}
			catch (Exception ex)
			{
				string Ex = ex.Message;
				return null;
			}
		}

		public int Set(string Data = "", int WaitingSendData = SerialService.WRITE_WAIT_MILLIS)
		{
			try
			{
				if (MainConnect == null)
				{
					return -1;
				}

				byte[] buffer = Encoding.ASCII.GetBytes(Data); // Convert Normal String to Number Code (Encoding ASCII)
															   //	await _Socket.OutputStream.WriteAsync(buffer, 0, buffer.Length); 
															   //Send Buffer to Bluthooht Device
				var WriteingData = MainConnect.Write(buffer, WaitingSendData);

				ListSendData = Data;

				return WriteingData;

			}
			catch (Exception ex)
			{
				string ME = ex.Message;
				return -2;
			}
		}

		public bool LoadUSB()
		{
			return true;
		}


		public SerialService()
		{
			Device.StartTimer(TimeSpan.FromMilliseconds(200), () =>
			{
				// called every 1 second
				// do stuff here

				var GetData = Get(0, true);

				if (!string.IsNullOrEmpty(GetData) && RecverData != null)
				{
					RecverData?.Invoke(ListSendData, GetData);
				}

				return true; // return true to repeat counting, false to stop timer
			});
		}





















		//#region UsbSerialPortAdapter implementation

		//class UsbSerialPortAdapter : ArrayAdapter<Hoho.Android.UsbSerial.Driver.IUsbSerialPort> 
		//{
		//	public UsbSerialPortAdapter(Context context)
		//		: base(context, global::Android.Resource.Layout.SimpleExpandableListItem2)
		//	{
		//	}

		//	public override View GetView(int position, View convertView, ViewGroup parent)
		//	{
		//		var row = convertView;
		//		if (row == null)
		//		{
		//			var inflater = Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
		//			row = inflater.Inflate(global::Android.Resource.Layout.SimpleListItem2, null);
		//		}

		//		var port = this.GetItem(position);
		//		var driver = port.GetDriver();
		//		var device = driver.GetDevice();

		//		var title = string.Format("Vendor {0} Product {1}",
		//			HexDump.ToHexString((short)device.VendorId),
		//			HexDump.ToHexString((short)device.ProductId));
		//		row.FindViewById<TextView>(global::Android.Resource.Id.Text1).Text = title;

		//		var subtitle = device.Class.SimpleName;
		//		row.FindViewById<TextView>(global::Android.Resource.Id.Text2).Text = subtitle;

		//		return row;
		//	}
		//}

		//#endregion

		//#region UsbDeviceDetachedReceiver implementation

		//class UsbDeviceDetachedReceiver
		//	: BroadcastReceiver
		//{
		//	readonly string TAG = typeof(UsbDeviceDetachedReceiver).Name;
		//	readonly MainActivity activity;

		//	public UsbDeviceDetachedReceiver(MainActivity activity)
		//	{
		//		this.activity = activity;
		//	}

		//	public async override void OnReceive(Context context, Intent intent)
		//	{
		//		var device = intent.GetParcelableExtra(UsbManager.ExtraDevice) as UsbDevice;

		//		//Log.Info(TAG, "USB device detached: " + device.DeviceName);
		//		//
		//		//await activity.PopulateListAsync();
		//	}
		//}

		//#endregion

		//#region UsbDeviceAttachedReceiver implementation

		//class UsbDeviceAttachedReceiver
		//	: BroadcastReceiver
		//{
		//	readonly string TAG = typeof(UsbDeviceAttachedReceiver).Name;
		//	readonly MainActivity activity;

		//	public UsbDeviceAttachedReceiver(MainActivity activity)
		//	{
		//		this.activity = activity;
		//	}

		//	public override async void OnReceive(Context context, Intent intent)
		//	{
		//		var device = intent.GetParcelableExtra(UsbManager.ExtraDevice) as UsbDevice;

		//		//	MainActivity.MainActivitY..Log.Info(TAG, "USB device attached: " + device.DeviceName);
		//		//
		//		//	await activity.PopulateListAsync();
		//	}
		//}

		//#endregion
	}
}
