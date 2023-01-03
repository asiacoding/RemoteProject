#include <IRremote.h>
#include <SoftwareSerial.h>

///////////////////////////////////////////////////////////////
const int BlueTX = 5;
const int BlueRX = 6;
const int IRLED = 3; 
const int PinReadIR = A4;
SoftwareSerial  bt(BlueRX, BlueTX); //bt obj
IRsend irsend; // ir send obj
String Data; // Data From Bt
decode_results results;
IRrecv irreader(PinReadIR);
////////////////////////////////////////////////////////////////////
void setup()
{
	bt.begin(9600); // Set Bluetooth Begin 
	pinMode(IRLED, INPUT); //Ir Led
	Serial.begin(9600); // Set Serial Begin 
	Serial.println("Start App");
	irreader.enableIRIn(); // Start the receiver
} 

uint32_t valueRemote = 0;

void AddNewSagnle()
{
	String Output = ""; 

	//Serial.println("Ready To Reader IR Remote ...");
	//Serial.print("Old Value int is :");
	//Serial.println(valueRemote);
	//Serial.print("Old Value String is :");
	//Serial.println(Output);
  
  
	Output = String(valueRemote, DEC);
	//Serial.print("Send TO Android App Code :");
	//Serial.println(Output);

	bt.write(Output.c_str()); // Send IR Code 
	bt.write(';'); //End Point
}

void SetSagnle()
{
  
	//Exmple 
	//       Type    |     Code
	//Data = "    NEC    :   123123125   ;"
	//  NEC is Tyeping 
  
	int index = Data.lastIndexOf(':');
	int length = Data.length(); // Last Index
	String code = Data.substring(index, length); //Code
  
	int indexLast = Data.indexOf(':');
	String Types = Data.substring(0, indexLast);
  
	Serial.print(" Print Value Normal Data : "); Serial.println(Data); //Print Value Normal Data : + Data ↵
	uint32_t X = String(Data.toInt(), DEC).toInt(); //Enter Line
	Serial.print(" Print Value : "); 
	Serial.println(X); //Print Value : + Data  ↵
	irsend.sendNEC(X, 32); // Send NEC
	bt.write("SedingCode");
	bt.write(String(Data.toInt(), DEC).c_str());
	bt.write(';');
  
}

void loop()
{
  
	if (irreader.decode(&results))// Returns 0 if no data ready, 1 if data ready.     
	{           
		if (results.value > 0 && irreader.getProtocolString() != "UNKNOWN" && results.value < 4294967295 ) 
		{
			
			valueRemote = results.value; // Results of decoding are stored in result.value     
			Serial.print("Code: ");     
			Serial.print(results.value); //prints the value a a button press     
			Serial.print(" , "); //prints the value a a button press     
			Serial.print("Protocol is : ");     
			Serial.println(irreader.getProtocolString());
		//	bt.write(String(results.value, DEC).c_str());
			//bt.write(';');
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
		}
		else
		{
			//Serial.println();
			//Serial.print("Recave Code : ");
			//Serial.println(Data);
			if (Data == "C") bt.write("Yes;"); // Is Online
			else if(Data == "A") AddNewSagnle(); // Get Data
			else SetSagnle(); // Send Data
			Data = "";
		}
	}
	delay(870);
}