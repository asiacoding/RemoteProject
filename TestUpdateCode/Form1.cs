using ArduinoUploader;
using ArduinoUploader.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TestUpdateCode
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			//ArduinoUploader 
		}

	    static string[] GetModelsBase = new[]
		{
				ArduinoUploader.Hardware.ArduinoModel.Leonardo.ToString(),
				ArduinoUploader.Hardware.ArduinoModel.Mega1284.ToString(),
				ArduinoUploader.Hardware.ArduinoModel.Mega2560.ToString(),
				ArduinoUploader.Hardware.ArduinoModel.Micro.ToString(),
				ArduinoUploader.Hardware.ArduinoModel.NanoR2.ToString(),
				ArduinoUploader.Hardware.ArduinoModel.NanoR3.ToString(),
				ArduinoUploader.Hardware.ArduinoModel.UnoR3.ToString()
			};

		private void button1_Click(object sender, EventArgs e)
		{
			//ArduinoSketchUploader.exe --file=C:\MyHexFiles\myHexFile.hex --model=UnoR3

			//ArduinoSketchUploader.exe --file=C:\Users\ehabm\Desktop\CRM.API\test\RemoteProject\TestUpdateCode\Blink.ino.hex --port=COM17 --model=NanoR2

			//		var uploader = new ArduinoSketchUploader(
			//new ArduinoSketchUploaderOptions()
			//{
			//	//
			//	FileName = @"Main.hex",
			//	PortName = textBox1.Text,
			//	ArduinoModel = ArduinoModel.NanoR3
			//});
			//		uploader.UploadSketch();

			//ArduinoSketchUploader.exe --file=C:\Users\ehabm\Desktop\CRM.API\test\RemoteProject\TestUpdateCode\Blink.ino.hex --port=COM15 --model=UnoR3

			if (listBox1.SelectedIndex== -1)
			{
				return;
			}

			string FilePath = System.IO.Path.GetFullPath(textBox1.Text);
			string Port = textBox2.Text;
			string models = GetModelsBase[listBox1.SelectedIndex];

			//ArduinoUploader

			string ComplitePath = $"{System.IO.Path.GetFullPath("ArduinoSketchUploader.exe")} --file={FilePath} --port={Port} model={models}";


			var process = new Process()
			{
				 
			};
 
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
			startInfo.FileName = "cmd.exe";
			startInfo.Arguments = $" {ComplitePath}";
			process.StartInfo = startInfo;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.Start();
     		string output = process.StandardOutput.ReadToEnd();
			process.WaitForExit();
			richTextBox1.Text = output;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			listBox1.Items.AddRange(GetModelsBase);
		}
	}









}
