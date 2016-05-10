// Seven Segment Display Controller Library
// Processor: MC9S12XDP512
// Crystal: 16 MHz
// by Brennan MacGregor
// September 2015

#include <hidef.h>
#include "derivative.h"
#include "my_Lib.h"

void ButtInit(void)
  {
    DDR1AD1   = 0b11100000;
    PT1AD1   &= 0b11100000;
    ATD1DIEN1 = 0b00011111;
  }

void SevSeg_Init(void)
{
  PORTA |= 0b00000011;    // preset sontrol lines high
  DDRA  |= 0b00000011;    // A0:1 outputs
  PORTB  = 0b11111111;    // preset data lines high
  DDRB   = 0b11111111;    // all PORTB outputs
  
  SevSeg_BlAll();        // blanked until we create this
}

// required a digit address (0 to 7) to blank
void SevSeg_BlChar(unsigned char cDigit)
{
  cDigit  &= 0b00000111;  // clean up in case of error
  cDigit  |= 0b00111000;  // single digit, (don't care), no decode, no SD, bank A
  
  PORTB    = cDigit;
  PORTA   &= 0b11111110;  // Mode stays high, strobe /Write
  PORTA   |= 0b00000011;  // back to resting state - Mode and /Write high
  
  PORTB   &= 0b10000000;  // prep the data digit: clear upper nibble
  PORTB   |= 0b10000000;  // no decimal point <------ THE DECIMAL ONE
  PORTA   &= 0b11111100;  // node low (data), /write low
  PORTA   |= 0b00000011;  // resting state: mode and /write HIGH
}

// blanks the display using the SevSeg_BlChar routine in an 8-cycle loop
void SevSeg_BlAll(void)
{
  unsigned char cCount;
  for(cCount = 0; cCount < 8; cCount++)
  {
    SevSeg_BlChar(cCount);
  }
}

void SevSeg_Char(unsigned char position, unsigned char character)
{
  position  &= 0b00000111;  // clean up in case of error
  position  |= 0b01011000;  // single digit, (don't care), no decode, no SD, bank A
  
  character &= 0b00001111;
  character |= 0b10000000;
  
  PORTB      = position;
  PORTA     &= 0b11111110;  // Mode stays high, strobe /Write
  PORTA     |= 0b00000011;  // back to resting state - Mode and /Write high
  
  PORTB      = character;
  PORTA     &= 0b11111100;  // prep the data digit: clear upper nibble
  PORTA     |= 0b00000011;  // no decimal point <------ THE DECIMAL ONE
}

void SevSeg_dChar(unsigned char position, unsigned char character)
{
  position  &= 0b00000111;  // clean up in case of error
  position  |= 0b01011000;  // single digit, (don't care), no decode, no SD, bank A
  
  character &= 0b00001111;
  //character |= 0b00000000; // or with zeroes for decimal 
  
  PORTB      = position;
  PORTA     &= 0b11111110;  // Mode stays high, strobe /Write
  PORTA     |= 0b00000011;  // back to resting state - Mode and /Write high
  
  PORTB      = character;
  PORTA     &= 0b11111100;  // prep the data digit: clear upper nibble
  PORTA     |= 0b00000011;  // no decimal point <------ THE DECIMAL ONE
}  
    
void SevSeg_Top4(unsigned int character) 
{
    SevSeg_Char(0, (character%10000/1000));
    SevSeg_Char(1, (character%1000/100));
    SevSeg_Char(2, (character%1000%100/10));
    SevSeg_Char(3, (character%1000%100%10));
}

void SevSeg_Top4Hex(unsigned int character) 
{
    SevSeg_Char(0, (character%65536/4096));
    SevSeg_Char(1, (character%4096/256));
    SevSeg_Char(2, (character%4096%256/16));
    SevSeg_Char(3, (character%4096%256%16));
}

void SevSeg_Bot4(unsigned int character)
{
    SevSeg_Char(4, (character%10000/1000));
    SevSeg_Char(5, (character%1000/100));
    SevSeg_Char(6, (character%1000%100/10));
    SevSeg_Char(7, (character%1000%100%10));
}

void SevSeg_Bot4Hex(unsigned int character)
{
    SevSeg_Char(4, (character%65536/4096));
    SevSeg_Char(5, (character%4096/256));
    SevSeg_Char(6, (character%4096%256/16));
    SevSeg_Char(7, (character%4096%256%16));
}    

void SevSeg_Cuty(unsigned char position, unsigned char character)
{
    position  &= 0b00000111;  // clean up in case of error
    position  |= 0b01111000;  // single digit, (don't care), no decode, no SD, bank A
  
    PORTB      = position;
    PORTA     &= 0b11111110;  // Mode stays high, strobe /Write
    PORTA     |= 0b00000011;  // back to resting state - Mode and /Write high
  
    PORTB      = character;
    PORTA     &= 0b11111100;  // prep the data digit: clear upper nibble
    PORTA     |= 0b00000011;  // no decimal point <------ THE DECIMAL ONE
}

void Delay(int milliSeconds)
  {
    int outer, inner;
    for(outer = 0; outer < milliSeconds; outer++)
      for(inner = 0; inner < 1400; inner++); 
  }
  
int R_Debounce(void)
  {
    // works on button release
    int checkOne, checkTwo; 
    checkOne = PT1AD1 & 0b00011111;
    Delay(20);
    checkTwo = PT1AD1 & 0b00011111;
    
    if (checkOne && !checkTwo)
      return 1;
    else
      return 0;
  }
  
  int P_Debounce(void)
  {
    // works on button press
    int checkOne, checkTwo; 
    checkOne = PT1AD1 & 0b00011111;
    Delay(20);
    checkTwo = PT1AD1 & 0b00011111;
    
    if (!checkOne && checkTwo)
      return 1;
    else
      return 0;
  }
  
  char SwCK(void)
  {
    char cSample1 = 1;
    char cSample2 = 0;
    
    while (cSample1 != cSample2)
      {
        cSample1 = PT1AD1 & 0b00011111;
        asm LDX  #26667;
        asm DBNE X,*;
        cSample2 = PT1AD1 & 0b00011111;
      }
      return cSample1;
  }

unsigned char HexToASCII(unsigned char hexInput) {
  unsigned char maskHex, ascReturn;
  maskHex = hexInput & 0b00001111;
  if(maskHex <= 9)
  ascReturn = maskHex +'0';
  else
  ascReturn = maskHex - 0xA + 'A';
  return ascReturn;
}

unsigned char ASCIIToHex(unsigned char ascInput) {
  unsigned char hexReturn;
  if(ascInput < '0')
  hexReturn = 0b11111111;
  else if(ascInput <= '9')
  hexReturn = ascInput - '0';
  else if(ascInput < 'A')
  hexReturn = 0b11111111;
  else {
    ascInput &= 0b11011111;
    if(ascInput <= 'F')
    hexReturn = ascInput - 'A' + 0xA;
    else
    hexReturn = 0b11111111;
  }
  return hexReturn;
}
    
void SCI0_Init19200(void) {
  SCI0BDH = 0;
  SCI0BDL = 26;  // 8 Mhz/(16 * 26) == 19231 Hz
  SCI0CR1 = 0;
  SCI0CR2 = 0b00001100; // Enable Tx (bit 3) and Rx (bit 2)
}

unsigned char SCI0_RxChar(void) {
  unsigned char kbChar;
  while(!(SCI0SR1 & 0b00100000)); // Do nothing repeatedly until a key is struck
  kbChar = SCI0DRL;
  return kbChar;
}

void SCI0_TxChar(unsigned char txChar) {
  while(!(SCI0SR1 & 0b10000000)); // Do nothing until TeraTerm is ready
  SCI0DRL = txChar;
}

void SCI0_TxString(unsigned char txString[]){
  int i = 0;
  while(txString[i] != 0)
    SCI0_TxChar(txString[i++]);
}

int HexToBCD(unsigned char cSum)
{
  unsigned char BCDInt;
  BCDInt = (cSum / 10) << 4;
  BCDInt = BCDInt | (cSum % 10);
  return BCDInt;
}

void LCD_Init(void) {
    PTH = 0b00000000;
    DDRH = 0b11111111;
    PORTK &= 0b11111000;
    DDRK |= 0b00000111;
    asm pshd;
    asm ldd #0;
    asm dbne d,*;
    asm dbne d,*;
    asm puld;
    PTH = 0b00111000;
    PORTK |= 0b00000001;
    PORTK &= 0b11111000;
    asm pshd;
    asm ldd #11000;
    asm dbne d,*;
    asm puld;
    PORTK |= 0b00000001;
    PORTK &= 0b11111000;
    asm pshd;
    asm ldd #267;
    asm dbne d,*;
    asm puld;
    PORTK |= 0b00000001;
    PORTK &= 0b11111000;
    asm pshd;
    asm ldd #267;
    asm dbne d,*;
    asm puld;
    LCD_Ctrl(0b00111000);
    LCD_Ctrl(0b00001110);
    LCD_Ctrl(0b00000001);
    LCD_Ctrl(0b00000110);
}

void LCD_Ctrl(unsigned char command) {
  while(LCD_Busy());
  PTH = command;
    PORTK |= 0b00000001;
    PORTK &= 0b11111000;
}

unsigned char LCD_Busy(void) {
  unsigned char cBusy;
  DDRH = 0b00000000;
  PORTK |= 0b00000011;
  PORTK &= 0b11111000;
  cBusy = PTH & 0b10000000;
  DDRH = 0b11111111;
  return cBusy;
}

void LCD_Char(unsigned char cChar) {
  while(LCD_Busy());
  PTH = cChar;
    PORTK |= 0b00000101;
    PORTK &= 0b11111000;
}
  
void LCD_Addr(unsigned char addrs) {
    while(LCD_Busy());
    PTH = 0b10000000 | (0b01111111 & addrs);
    PORTK |= 0b00000001;
    PORTK &= 0b11111000;
}
    
void LCD_Pos(unsigned char row, unsigned char column) {
	unsigned int result = 0x00;
	if(row == 1)
		result += column;
	else if(row == 2)
		result += 0x40 + column;
	else if(row == 3)
		result += 0x14 + column;
	else if(row == 4)
		result += 0x54 + column;
	
	LCD_Addr(result);
}

void LCD_String(char message[]) {
    unsigned int count = 0;
    unsigned char cChar = message[count];
    
    while (cChar != 0x00)
      {
         LCD_Char(cChar);
         count++;
         cChar = message[count];
      };
 }
 
void LCD_MyInitials(void)
  {
      LCD_Addr(0x8);
      LCD_Char('B');
      LCD_Char('J');
      LCD_Char('A');
      LCD_Char('M');

      LCD_Ctrl(0b00001111);
  }

void LCD_StringwDelay(char message[])
  {
    unsigned int count = 0;
    unsigned char cChar = message[count];
    
    while (cChar != 0x00)
      {
         LCD_Char(cChar);
         count++;
         cChar = message[count];
         Delay(150);
      };
  }
  
void PWMEMusicBoxInit(void)
  {
      PWME = 0;
      PWMCLK = 0;
      PWMPRCLK = 0b01100000;
      PWMPOL = 0;
  }
  
void PlayC(void)
  {
    PWMPER6 = 239;
    PWMDTY6 = 120;
    PWME = 0b01000000;
    while (PT1AD1 & 0b00001000);
    PWME = 0;
  }
  
void PlayD(void)
  {
    PWMPER6 = 212;
    PWMDTY6 = 106;
    PWME = 0b01000000;
    while (PT1AD1 & 0b00000001);
    PWME = 0;
  }
  
void PlayE(void)
  {
    PWMPER6 = 190;
    PWMDTY6 = 95;
    PWME = 0b01000000;
    while (PT1AD1 & 0b00000010);
    PWME = 0;
  }
  
void TimInit8us(void)
  {
    TSCR1 |= 0b10000000;  // enable timer module
    TSCR2 &= 0b11111000;  // set prescale to Bus/64 (8 us per tick)
    TSCR2 |= 0b00000110;  // ...continued
    TIOS  |= 0b00000001;  // set IOS0 to output compare
    TCTL2 &= 0b11111100;  // set PT0 to toggle mode
    TCTL2 |= 0b00000001;  // ...continued
    TFLG1 |= 0b00000001;  // clear flag
  }
  
void PWMInit(void)
  {
     PWMPOL   = 0b11111111;   // positive polarity, all channels
     PWMCLK  |= 0b01000000;   // Use SB as the clock for channel 6 (speaker)
     /* 1 kHz = 8,000,000 / (2^2 * 2 * 4 * 250) */
     PWMPRCLK &= 0b00001111;  // clear PRE-B before setting
     PWMPRCLK |= 0b00100000;  // PRE-B = 2^2
     PWMSCLB   = 7;           // Scale = 2 * 7 - used to be 4
  }
  
void Sleep_ms(unsigned int iTime)  // requires TimInit8us
  {
    unsigned int iCount;
    TC0 = TCNT + 125; // first target -- 125 counts at 8 us = 1 ms
    for (iCount = 1; iCount <= iTime; iCount++)
      {
        TFLG1 |= 0b00000001;  // clear flag
        while ((TFLG1 & 0b00000001) == 0);  // BLOCKING, wait for flag
        TC0   += 125; // next target -- based on previous target for accuracy
      }
  }
  
void PWMLightBlueInit(unsigned int period, unsigned int dty)
  {
     PWMPER0   = period;
     PWMDTY0   = period / dty;
     
     // in a while loop, PWME ^= 0b00001011; will activate the LED
  } 
   
void PWMLightGreenInit(unsigned int period, unsigned int dty)
  {
     PWMPER1   = period;
     PWMDTY1   = period / dty;
  }



void PWMLightRedInit(unsigned int period, unsigned int dty)
  {
     PWMPER4   = period;
     PWMDTY4   = period / dty;
  }
  
void PWMSpeaker(void)
  {
     PWMPER6   = 250;         // keep the period number large for accuracy
     PWMDTY6   = 125;         // 50% duty cycle
     
     /* FOR ALARM CLOCK 
          Sleep_ms(500);       // half second on, half second off
          PWME ^= 0b01000000;  // by toggling PWME6  */
  }