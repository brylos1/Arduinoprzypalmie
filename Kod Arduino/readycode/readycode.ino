#include <OneWire.h>
#include <DallasTemperature.h>
#include <RTClib.h>
#include <SPI.h>
#define ONE_WIRE_BUS 6
RTC_DS3231 rtc;

char daysOfTheWeek[7][12] = {
  "Sunday",
  "Monday",
  "Tuesday",
  "Wednesday",
  "Thursday",
  "Friday",
  "Saturday"
};
OneWire oneWire(ONE_WIRE_BUS);
DallasTemperature sensors(&oneWire);
uint8_t gleba[8] ={0x28, 0xDC, 0xFE, 0xD3, 0xC0, 0x21, 0x09, 0xE0 };
uint8_t powietrze[8] =  { 0x28, 0xF0, 0xB1, 0xE0, 0xC0, 0x21, 0x08, 0x33 };
byte mytime =0;
float sumaGleba=0;
float sumaPowietrze=0;



void setup() {
  Serial.begin(9600);

 if (! rtc.begin()) {
    Serial.println("Couldn't find RTC");
    Serial.flush();
    while (1);
  }
  
  sensors.begin();
  pinMode(3, OUTPUT);
pinMode(2, OUTPUT);
digitalWrite(2, HIGH);
    digitalWrite(3, HIGH);
}
float Temperature(DeviceAddress deviceAddress)
{
  float tempC = sensors.getTempC(deviceAddress);
  return tempC;
}
void loop() {
DateTime now = rtc.now();

  sensors.requestTemperatures();
  float glebatemp=Temperature(gleba);
  float powietrzetemp=Temperature(powietrze);
  sumaGleba+=glebatemp;
  sumaPowietrze+=powietrzetemp;
  mytime++;
  
  if(mytime>=60){
    float avgair =sumaPowietrze/mytime;
    float avggleba=sumaGleba/mytime;
  if(avgair<15){
    digitalWrite(2, LOW);
    digitalWrite(3, LOW);
  }if(avgair>18){
    digitalWrite(2, HIGH);
    digitalWrite(3, HIGH);
    }
  sumaGleba=0;
  sumaPowietrze=0;
  String data = String(now.year(),DEC)+'-'+String(now.month(),DEC)+'-'+String(now.day(),DEC)+' '+String(now.hour(),DEC)+':'+String(now.minute(),DEC)+':'+String(now.second(),DEC) +
  ';'+avggleba+';'+avgair+';'+!digitalRead(3);
    Serial.println(data);
  mytime=0;
  }
delay(350);
}
