#include <IRremote.h>
#include <SoftwareSerial.h>

/////////////////////////////////////////////////////////////
const int BlueTX = 6;
const int BlueRX = 7;
//const int IRLED = 3; // Old 5 
//IR LED PIN IN File ( IRremoteBoardDefs.h)
//#define IR_SEND_PIN  3              // Arduino Duemilanove, Diecimila, LilyPad, etc
const int PinReadIR = A4;
const int ResetPin = 2; //Set 0 To ResatApp
int IndexStatus = 0; 
bool SendSagnle = false;
SoftwareSerial  bt(BlueRX, BlueTX); //bt obj
IRsend irsend; // ir send obj
String Data; // Data From Bt
decode_results results;
IRrecv irreader(PinReadIR);
//////////////////////////////////////////////////////////////////


void SetSagnle()
{

}

uint32_t ReadIRFROMRemote()
{
	uint32_t valueRemote = 0;
	bool OutMethod = false;
	do
	{
		if (irreader.decode(&results))// Returns 0 if no data ready, 1 if data ready.     
		{           
			if (results.value > 0 && irreader.getProtocolString() != "UNKNOWN" && results.value < 4294967295) 
			{
				valueRemote = results.value; /* Results of decoding are stored in result.value */   //  Serial.print("Code: "); Serial.print(results.value); /* prints the value a a button press*/ Serial.print(" , "); /*prints the value a a button press */  Serial.print("Protocol is : "); Serial.println(irreader.getProtocolString());
				OutMethod = true;
			}
			irreader.resume();
		}
		if (OutMethod) break;
	} while (true);
	return valueRemote;
}

void setup()
{
	bt.begin(9600); // Set Bluetooth Begin 
	digitalWrite(ResetPin, HIGH); //
	pinMode(ResetPin, OUTPUT); //
	Serial.begin(9600); /* Set Serial Begin */ 
	Serial.println(); 
	Serial.println("Start App;");
	irreader.enableIRIn(); // Start the receiver
} 

void loop()
{ 
	//while (Serial.available())
	while (bt.available())
	{
		//delay(20);
		char ch = char(bt.read());
		//char ch = char(Serial.read());
		if (ch != ';')
		{
			Data += ch;
			//Serial.println(Data);
		}
		else
		{     
			Serial.print("ruinginCode: "); Serial.println(Data);
			if (Data == "GetCodes")
			{
				Serial.print("Read IR Reader is Waiting ! ");
				uint32_t ValueOn = ReadIRFROMRemote();
				if (ValueOn > 0)
				{
					Serial.print("Send TO Android App Code :");
					Serial.println(String(ValueOn, DEC));
					bt.write(String(ValueOn, DEC).c_str()); // Send IR Code 
					bt.write(';'); //End Point
				}
				else
				{
					Serial.print("No Code In Storage !!");
					bt.write("NoCodeInStorage!!;"); // Send IR Code 
				}
				Serial.print("Read IR Reader is Ending .. Done!!");
			}
			else 
			{
				Serial.print(" Print Value Normal Data : "); Serial.println(Data); //Print Value Normal Data : + Data ???
				uint32_t X = String(Data.toInt(), DEC).toInt(); //Enter Line
				Serial.print(" Print Value : "); Serial.println(X); //Print Value : + Data  ???
				irsend.sendNEC(X, 32); // Send NEC
			}// SetSagnle(); //Send Data
			Data = "";		 
			delay(600);
		} 
	}
}

