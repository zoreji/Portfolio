// Seven Segment Display Controller Library
// Processor: MC9A12XD9512
// Crystal: 16 MHz
// by Brennan MacGregor
// Septembter 2015

void SevSeg_Init(void);                         
void ButtInit(void);
void SevSeg_Char(unsigned char, unsigned char);  // character and digit address
void SevSeg_BlChar(unsigned char);               // digit address
void SevSeg_BlAll(void);
void SevSeg_dChar(unsigned char, unsigned char); // character and digit address
void SevSeg_Top4(unsigned int);
void SevSeg_Top4Hex(unsigned int character);                  // four chars compressed as four nibbles in an int
void SevSeg_Bot4(unsigned int);
void SevSeg_Bot4Hex(unsigned int character);                  // four chars compressed as four nibbles in an int
void SevSeg_Cuty(unsigned char, unsigned char);  // selected segments and digit address
void Delay(int);
int R_Debounce(void);
int P_Debounce(void);
char SwCK(void);
unsigned char HexToASCII(unsigned char);
unsigned char ASCIIToHex(unsigned char);
void SCI0_Init19200(void);
unsigned char SCI0_RxChar(void);
void SCI0_TxChar(unsigned char);
void SCI0_TxString(unsigned char[]);
int HexToBCD(unsigned char);

void LCD_Init(void);
void LCD_Ctrl(unsigned char);
unsigned char LCD_Busy(void);
void LCD_Char(unsigned char);
void LCD_Addr(unsigned char);
void LCD_Pos(unsigned char, unsigned char); // Develop the definition, below
void LCD_String(char[]);                    // Develop the definition, below
void LCD_MyInitials(void);
void LCD_StringwDelay(char message[]);

void PWMEMusicBoxInit(void);
void PlayC(void);
void PlayD(void);
void PlayE(void);

void TimInit8us(void);  // added for the exam
void PWMInit(void);
void Sleep_ms(unsigned int iTime);
void PWMLightBlueInit(unsigned int period, unsigned int dty);
void PWMLightGreenInit(unsigned int period, unsigned int dty);
void PWMLightRedInit(unsigned int period, unsigned int dty);
void PWMSpeaker(void);