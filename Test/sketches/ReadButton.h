#include <IRremote.h>
const int PinReadIR = A4;
decode_results results;
IRrecv irreader(PinReadIR);

void setup() {
	// put your setup code here, to run once:
  


	Serial.begin(9600); // Set Serial Begin 
  
	irreader.enableIRIn(); // Start the receiver

}
uint32_t valueRemote = 0;
void loop() {
	// put your main code here, to run repeatedly:
  
	if (irreader.decode(&results))// Returns 0 if no data ready, 1 if data ready.     
	{         
		//  valueRemote = results.value; // Results of decoding are stored in result.value    
		irreader.resume(); // Restart the ISR state machine and Receive the next value  
		valueRemote = results.value; // Results of decoding are stored in result.value     
		Serial.println(results.value, BIN); //prints the value a a button press     

		irreader.resume();
	}

	delay(1000);
}