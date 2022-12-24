#include <SevSeg.h>
SevSeg sevseg;


char Abc[37] = {
'A','B','C','D','E',
'F','G','H','I','J',
'K','L','M','N','O',
'P','Q','R','S','T',
'U','V','X','Y','Z',
'1','2','3','4','5',
'6','7','8','9','0',

' ' //End

};


void setup() {
    byte numDigits = 1;
    byte digitPins[] = {};
    byte segmentPins[] = { 6, 5, 2, 3, 4, 7, 8, 9 };
    bool resistorsOnSegments = true;

    byte hardwareConfig = COMMON_CATHODE;
    sevseg.begin(hardwareConfig, numDigits, digitPins, segmentPins, resistorsOnSegments);
    sevseg.setBrightness(90);
}

void loop() {
    sevseg.setChar(Abc);
    sevseg.refreshDisplay();
    delay(1000);
}