using System;
using System.Collections.Generic;
using System.Text;

namespace BlueApp1.Interface
{
	public interface USBSerial
	{

		/// <summary>
		/// 
		/// </summary>
		string ListSendData { set; get; }
		
		/// <summary>
		/// 
		/// </summary>
		event EventHandler<string> RecverData;
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		bool LoadUSB();
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Data"></param>
		/// <param name="WaitingSendData"></param>
		/// <returns></returns>
		int Set(string Data = "", int WaitingSendData = 2000);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="WaitReaderData"></param>
		/// <param name="ConvertToString"></param>
		/// <returns></returns>
		string Get(int WaitReaderData = 2000, bool ConvertToString = true);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		List<string> GetList();
		/// <summary>
		/// 
		/// </summary>
		string HotLine {  get; }
	}
}
