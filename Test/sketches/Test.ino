#include <IRremote.h>
#include <SoftwareSerial.h>

/////////////////////////////////////////////////////////////
//const int BlueTX = 7;
//const int BlueRX = 6;

//static int CountLooping = 0;

// const int IRLED = 3; // Old 5

// IR LED PIN IN File ( IRremoteBoardDefs.h)
// #define IR_SEND_PIN  3              // Arduino Duemilanove, Diecimila, LilyPad, etc

const int PinReadIR = A4;
const int ResetPin = 2; // Set 0 To ResatApp
int IndexStatus = 0;
bool SendSagnle = false;
//SoftwareSerial bt(BlueRX, BlueTX); // bt obj
IRsend irsend;             // ir send obj
String Data;             // Data From Bt
decode_results results;
IRrecv irreader(PinReadIR);
//////////////////////////////////////////////////////////////////

uint32_t ReadIRFROMRemote()
{
    uint32_t valueRemote = 0;
    bool OutMethod = false;
    do
    {
        if (irreader.decode(&results)) // Returns 0 if no data ready, 1 if data ready.
        {

            if (results.value > 0 && irreader.getProtocolString() != "UNKNOWN" && results.value < 4294967295 && results.value != 255)
            {

                valueRemote = results.value; /* Results of decoding are stored in result.value */ //  Serial.print("Code: "); Serial.print(results.value); /* prints the value a a button press*/ Serial.print(" , "); /*prints the value a a button press */  Serial.print("Protocol is : "); Serial.println(irreader.getProtocolString());

                OutMethod = true;
            }
            irreader.resume();

        }

        if (OutMethod)
            break;

    } while (true);
    return valueRemote;
}

void SendIRLED()
{
    uint32_t X = String(Data.toInt(), DEC).toInt(); // Enter Line
    Serial.println(X);
    irsend.sendNEC(X, 32); // Send NEC
    Write(String(Data.toInt(), DEC).c_str());
}

void GetIRData()
{
    uint32_t ValueOn = ReadIRFROMRemote();
    if (ValueOn > 0)
    {
        //Serial.print("Send TO Android App Code :"); Serial.println(String(ValueOn, DEC));
        //bt.write(String(ValueOn, DEC).c_str()); // Send IR Code
        //bt.write(';');                          // End Point
        Write(String(ValueOn, DEC).c_str());
    }
    else
    {
        //Serial.print("No Code In Storage !!");
        Write("NoCodeInStorage!!");
        //bt.write("NoCodeInStorage!!;"); // Send IR Code
    }
    // Serial.print("Read IR Reader is Ending .. Done!!");
}

void Rest()
{

    digitalWrite(ResetPin, LOW);
    //try
    //{
    //
    //}
    //catch (const std::exception&)
    //{
    //    
    //}
}

void IsConnect() {
    //bt.write("YesIsConenct;"); // Send IR Code 
    Write("YesIsConenct");
}

void Write(char* GetList) {
    Serial.print(GetList);
    Serial.println(';');
}

void setup()
{
    // bt.begin(9600); // Set Bluetooth Begin

     //If Send 0 To Moudlue rest is need to in add new sagnle Remotes
    digitalWrite(ResetPin, HIGH); //
    pinMode(ResetPin, OUTPUT); //
    digitalWrite(ResetPin, HIGH); //

    Serial.begin(9600); // Set Serial Begin  
    Write("Welcome to Magical Stick (IR)");
    irreader.enableIRIn(); // Start the receiver
}


void loop()
{



    while (Serial.available())
        //while (bt.available())
    {


        //    delay(20);
        char ch = char(Serial.read());
        //char ch = char(bt.read());
        if (ch != ';')
        {
            Data += ch;
        }
        else
        {


            //   CountLooping = CountLooping + 1;
            //   char* Count = 'Looping' + String(CountLooping, DEC).c_str();
            //   Write(Count);


            //Write(Data.c_str());
            //      Serial.println(Data);
                //  Serial.print("ruinginCode: ");
                //  Serial.println(Data);

            if (Data == "getcodes")
            {
                GetIRData();
            }
            else if (Data == "restmodels")
            {
                Rest();
            }
            else if (Data == "isconnect")
            {
                IsConnect();
            }
            else
            {
                SendIRLED();
            }




            Data = "";

            delay(200);
        }
    }
}
