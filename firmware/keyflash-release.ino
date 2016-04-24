/* Keyflash, версия 1.0
 * Прошивка для аппаратной части комплекса
 * Дата: 4 апреля 2016
 * keyflash@chiruno.xyz
 */
#include <SoftwareSerial.h>
#include <OneWire.h>
#define PROGPIN 8 // вывод, используемый для программирования
#define DEBUGTX 10 // пины подключения виртуального
#define DEBUGRX 11 // порта для отладки
bool connected = false;
byte key_to_write[8];
byte data[8];
SoftwareSerial debug(DEBUGTX, DEBUGRX);  // TX/RX для дебага
OneWire outpin(PROGPIN); // перевод вывода в режим работы с OneWire-устройствами
void setup() // код этой функции выполняется один раз при включении
{
    Serial.begin(9600); // открыть порты на скорости 9600 бод
    debug.begin(9600);
}

void loop() { // код этой функции выполняется циклически
while(!connected) // ожидание подключения
    {
        while (!Serial) ;
        Serial.print("Keyflash\n1.0-leo\n");
        delay(1000);
        if(Serial.read() == 'K') // если прочитана команда на подключение...
        {
            connected = true; // установить флаг подключения
            debug.println("connected to a client");
            break; // и прекратить гадить в порт
        }
    }
    switch(Serial.read()) // ожидание команды
    {
        case '0': // считывание
          debug.println("reading a key");
          outpin.reset(); // сброс интерфейса
          delay(50);
          outpin.write(0x33); // команда на чтение
          outpin.read_bytes(data, 8); // считывание ключа
          for(uint8_t i=0; i<8; i++) 
          {
              Serial.print(data[i], HEX); // и его вывод
              debug.print(data[i], HEX);
              if (i != 7) { Serial.print(":"); debug.print(":");}
          }
          Serial.print("T"); // символ окончания
          debug.println();
          debug.println("key read OK");
          break;
        case '1': // запись rw1990
          debug.println("rw1990");
          Serial.read(); // откуда-то всегда появляется лишний байт в начале
          while(Serial.available() < 9) {}; // ожидание полной передачи кода
          for(uint8_t g=0; g<8; g++) // и его чтение
            key_to_write[g] = Serial.read();
            
          for(uint8_t g=0; g<8; g++) // вывод полученного кода на отладочный порт
          {
              debug.print(key_to_write[g], HEX);
              if (g!=7) debug.print(":");
          }
          debug.println();
            
          outpin.reset(); // чёрная магия записи rw1990
          outpin.write(0xD1, 1); // команда на переход в режим программирования
          digitalWrite(PROGPIN, LOW);
          delayMicroseconds(60);
          digitalWrite(PROGPIN, HIGH);
          delay(2);
          outpin.reset();
          outpin.write(0xD5, 1); // и на запись
          for(int i=0; i<8; i++)
           rw1990_write(~key_to_write[i]); // передача кода в ключ
          outpin.reset();
          outpin.write(0xD1, 1); // отключение режима программирования
          digitalWrite(PROGPIN, LOW);
          delayMicroseconds(6);
          digitalWrite(PROGPIN, HIGH);
          delay(2);
          break;
          
        case '2': // запись rw2004
          debug.println("rw2004");
          Serial.read(); // считывание кода из порта, см. rw1990
          while(Serial.available() < 9) {}; 
          for(int g=0; g<8; g++)
            key_to_write[g] = Serial.read();
          
          for(uint8_t g=0; g<8; g++) // вывод полученного кода на отладочный порт
          {
              debug.print(key_to_write[g], HEX);
              if (g!=7) debug.print(":");
          }
          debug.println();

          for (uint8_t i=0; i<8; i++) // каждый байт пишется отдельно
            {              
              outpin.reset();
              data[0] = 0x3C; // команда на запись
              data[1] = i; // номер записываемого байта
              data[2] = 0;
              data[3] = key_to_write[i]; // сам байт для записи
              outpin.write_bytes(data, 4); // отправка на ключ
              //Serial.print(".");  
              uint8_t crc = outpin.read();    // проверка контрольной суммы,
              if (OneWire::crc8(data, 4) != crc) // требуется для записи
              {
                debug.println("epic fail");
                return;
              }
              else
              {
              pinMode(PROGPIN, OUTPUT); // подтверждение записи байта
              digitalWrite(PROGPIN, HIGH); 
              delay(60);
              digitalWrite(PROGPIN, LOW); 
              delay(5);
              digitalWrite(PROGPIN, HIGH); 
              delay(50); 
              }
            }
            debug.println("done");
            break;



          case 'Z': // отключение
            connected = false;
            break;
            
  }
}

void rw1990_write_bit(uint8_t data) // у rw1990 очень извращенный протокол
{
  digitalWrite(PROGPIN, LOW);
  if (data)
    delayMicroseconds(6);
  else
    delayMicroseconds(60);
  digitalWrite(PROGPIN, HIGH);
  delay(2);
}

void rw1990_write(uint8_t data) // сам Черный Властелин отдыхает
{ 
  for(uint8_t i=0; i<8; i++)
  {
    rw1990_write_bit(data & 0x01);
    data >>= 1;
  }
}
