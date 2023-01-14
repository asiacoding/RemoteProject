#include <IRremote.h>
#include <SoftwareSerial.h>

//T6
//R7
/////////////////////////////////////////////////////////////
const int BlueTX = 6;
const int BlueRX = 7;
//const int IRLED = 3; // Old 5 
//IR LED PIN IN File ( IRremoteBoardDefs.h)
//#define IR_SEND_PIN  3              // Arduino Duemilanove, Diecimila, LilyPad, etc
const int PinReadIR = A4;
//const int ResetPin = A2; //Set 1 To ResatApp
SoftwareSerial  bt(BlueRX, BlueTX); //bt obj
IRsend irsend; // ir send obj
String Data; // Data From Bt
decode_results results;
IRrecv irreader(PinReadIR);
//////////////////////////////////////////////////////////////////
void setup()
{
	// Set Bluetooth Begin 
	bt.begin(9600);
	//Normal Led ( Old System IR LED )

	//digitalWrite(ResetPin, HIGH);
	//pinMode(ResetPin, OUTPUT);
	// Set Serial Begin 
	Serial.begin(9600); 
	Serial.println("Start App");
	// Start the receiver
	irreader.enableIRIn(); 
} 

uint32_t valueRemote = 0;
int IndexStatus = 0; 
bool SendSagnle = false;

void AddNewSagnle()
{


	//Serial.println("Ready To Reader IR Remote ...");
	//Serial.print("Old Value int is :");
	//Serial.println(valueRemote);
	//Serial.print("Old Value String is :");
	//Serial.println(Output);
	if (valueRemote > 0)
	{
		Serial.print("Send TO Android App Code :");
		Serial.println(String(valueRemote, DEC));
		bt.write(String(valueRemote, DEC).c_str()); // Send IR Code 
		bt.write(';'); //End Point
	}
	else
	{
		Serial.print("No Code In Storage !!");
		bt.write("NoCodeInStorage!!;"); // Send IR Code 
	}
}
void SetSagnle()
{
  
	//	Exmple 
	//	       Type    |     Code
	//	Data = "    NEC    :   123123125   ;"
	//	  NEC is Tyeping 
	//int index = Data.lastIndexOf(':');
	//int length = Data.length(); // Last Index
	//String code = Data.substring(index, length); //Code
	//int indexLast = Data.indexOf(':');
	//String Types = Data.substring(0, indexLast);
  
	Serial.print(" Print Value Normal Data : "); Serial.println(Data); //Print Value Normal Data : + Data ↵
	uint32_t X = String(Data.toInt(), DEC).toInt(); //Enter Line
	Serial.print(" Print Value : "); Serial.println(X); //Print Value : + Data  ↵
	irsend.sendNEC(X, 32); // Send NEC
	//bt.write("SedingCode");
	//bt.write(String(Data.toInt(), DEC).c_str());
	//bt.write(';');
  
}
void RestartApp()
{
  
	//Serial.println("Reseting Programs To NextLin "); 
    //  
	//digitalWrite(ResetPin, LOW);
	//Serial.println("Resting Programers : Fail "); 
}



void loop()
{
	if (irreader.decode(&results))// Returns 0 if no data ready, 1 if data ready.     
	{           
		//Serial.print("NormalCode: "); Serial.print(results.value); /* prints the value a a button press*/      
		//Serial.print(" , "); /*prints the value a a button press */  Serial.print("Protocol is : "); Serial.println(irreader.getProtocolString());
		
		if (results.value > 0 && irreader.getProtocolString() != "UNKNOWN" && results.value < 4294967295) 
		{
			valueRemote = results.value; /* Results of decoding are stored in result.value */
			Serial.print("Code: "); Serial.print(results.value); /* prints the value a a button press*/     
			Serial.print(" , "); /*prints the value a a button press */  Serial.print("Protocol is : "); Serial.println(irreader.getProtocolString());
			IndexStatus = IndexStatus != 0 ? 0 : 1;
			digitalWrite(IRLED, IndexStatus);
		}
		irreader.resume();
	}
	

	
	while (bt.available())
	{
		delay(20);
		char ch = char(bt.read());
		if (ch != ';')
		{
			Data += ch;
			Serial.println(Data);
		}
		else
		{
			//if (Data == "Check") { bt.write("Yes;"); } else if(Data == "Claer") { Serial.flush(); } else if(Data == "ResetApp") {RestartApp(); }
			
			Serial.print("ruinginCode: "); Serial.println(Data);
			if(Data == "A") 
			{
				AddNewSagnle();
			} // Get Dataa
			else SetSagnle(); //Send Data
			Data = "";
			delay(1000);
		} 
	}


}