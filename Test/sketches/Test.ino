#include <IRremote.h>
#include <SoftwareSerial.h>

///////////////////////////////////////////////////////////////
const int BlueTX = 5;
const int BlueRX = 6;
const int IRLED = 3; 
const int PinReadIR = A5;
SoftwareSerial  bt(BlueRX, BlueTX); //bt obj
IRsend irsend; // ir send obj

String Data; // Data From Bt
decode_results results;
IRrecv irreader(PinReadIR);
////////////////////////////////////////////////////////////////////

void PrintMsg(String X)
{
	Serial.print(" Print Value : ");
	Serial.println(X);

}

//String strs[20];

//void Spliteing(String  str)
//{
//	int StringCount = 0;
//	while (str.length() > 0)
//	{
//		int index = str.indexOf(' ');
//		if (index == -1) // No space found
//		{
//			strs[StringCount++] = str;
//			break;
//		}
//		else
//		{
//			strs[StringCount++] = str.substring(0, index);
//			str = str.substring(index + 1);
//		}
//	}
//}
	



int LoadingKey()
{
	int Key = 0;
	return Key;
}

void Loadapp()
{
	
}



void setup()
{
	bt.begin(9600); // Set Bluetooth Begin 
	pinMode(IRLED, INPUT); //Ir Led
	Serial.begin(9600); // Set Serial Begin 
	irreader.enableIRIn(); // Start the receiver

}

void loop()
{
	char ch;
	while (bt.available())
	{
		delay(10);
		ch = char(bt.read());
		if (ch != ';')
		{
			Data += ch;
		}
		else
		{
			if (Data == "CheckIsOnline")
			{
				bt.write("Yes;");
			}
			else if (Data == "AddNewKey")
			{
				String Output = ""; 
				do
				{
					Output = "";
					if (irreader.decode(&results))
					{     
						int value = results.value;  
						Serial.println(results.value,BIN);
						Output = String(value, BIN);
						irreader.resume(); 
					}
				} while (Output == 0);
				bt.write(Output.c_str());
				bt.write(';');
			}
			else
			{
				uint32_t X = String(Data.toInt(), DEC).toInt();
				PrintMsg(String(X, DEC)); //See Massge
				irsend.sendNEC(X, 32);
			}
			Data = "";
		}
	}
	delay(200);
}

