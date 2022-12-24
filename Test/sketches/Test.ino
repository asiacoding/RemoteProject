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


int LoadingKey()
{
  
	int Key = 0;
  


	return Key;
}

void Loadapp()
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
        
				bt.write(LoadingKey());
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



void setup()
{
	bt.begin(9600); // Set Bluetooth Begin 
	pinMode(IRLED, INPUT); //Ir Led
	Serial.begin(9600); // Set Serial Begin 
	irreader.enableIRIn(); // Start the receiver
}

void loop()
{

	while (Serial.available())
	{
		String Str = Serial.readString();
    
		if (Str == "CheckIsOnline")
		{
			Serial.write("Ok\n");
			//bt.write("Yes;");
		}
		else if (Str == "AddNewKey")
		{
			Serial.println("Ready");
			while (true)
			{
    


				if (irreader.decode(&results)) {
   
					Serial.println(results.value, HEX);

					irreader.resume(); // Receive the next value
				}
  
        
			}
			Serial.println("DaneSending .");
		}
    
	} 
  
  
  
  
  
  
  
	//Loadapp();
}


//void GetHexDesmaple()
//{
//  String incomingByte = "";
//  int32_t OutputTVSagnle = 0;
//  int16_t Ckeck = 0;
//  if (Serial.available() > 0) 
//  {
//    char NewChar = char(Serial.read());
//    incomingByte += NewChar;
//    if (NewChar == ';')
//      Ckeck = 1;
//  }
//  
//  if (Ckeck == 1)
//  {
//    OutputTVSagnle = incomingByte.toInt();  
//    
//    float OutputTVSagnle1 = float(String(OutputTVSagnle, DEC).toInt());
//    //------------------------------------------------
//    Serial.println("---------------------------------------------------------");
//    Serial.println();
//    //-------------------------------------------------
//    Serial.print("OutPut :");
//    Serial.println(OutputTVSagnle1);
//    //-------------------------------------------------
//    Serial.print("DEC :");
//    Serial.println(String(OutputTVSagnle, DEC));
//    //-------------------------------------------------
//    Serial.print("BIN :");
//    Serial.println(String(OutputTVSagnle, BIN));
//    //-------------------------------------------------
//    Serial.print("HEX :");
//    Serial.println(String(OutputTVSagnle, HEX));
//    //-------------------------------------------------
//    Serial.println();
//    Serial.println("---------------------------------------------------------");
//    //-------------------------------------------------
//    Ckeck = 0;
//    incomingByte = "";
//    OutputTVSagnle = 0;
//  }
//}

