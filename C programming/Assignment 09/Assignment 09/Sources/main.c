/********************************************************************
*HC12 Program:	ICA 9 Fall, 2015
*Processor:		MC9S12XDP512
*Xtal Speed:	16 MHz
*Author:		Brennan MacGregor
*Date:			October 2015
*
*Details: Adds two single-digit numbers from dumb terminal, displays result in BCD
********************************************************************/

#include <hidef.h>      	// common defines and macros
//#include <stdio.h>		// ANSI C Standard Input/Output functions
//#include <math.h>			// ANSI C Mathematical functions
#include "derivative.h"    	// derivative-specific definitions

/********************************************************************
*		Library includes
********************************************************************/

#include "my_Lib.h"

/********************************************************************
*		Prototypes
********************************************************************/



/********************************************************************
*		Variables
********************************************************************/

unsigned char cClearScreen[16] = "\x1B[2J\x1B[1;1f";					//clears screen, goes to (Row1,Column1)
unsigned char cStartString[31] = "\x1B[35m\x1B[1;5fPositive Adding";	//Magenta text at (1,5)

unsigned char cYes = 'Y';											//initialize response to enter while loop

unsigned char cStringA[] = "\x1B[30m\x1b[3;10fA =  ";				//Black text at (3,10), Prompt for A
unsigned char cStringB[] = "\x1B[4;10fB =  ";						//text at (4,10), Prompt for B
unsigned char cStringX[] = "\x1B[5;10fA + B = "; 					//text at (5,10), Display text for result
unsigned char cAgainString[] = "\x1B[7;5fAgain? (y/n) ";			//text at (7,5), Prompt for repeat
unsigned char cGoodbyeString[] = "\x1B[32m\x1B[9;5fGoodbye!";				//text at (9,5), Goodbye message in Green


unsigned char cInChar;
unsigned char cSum;
unsigned char cOut;

/********************************************************************
*		Lookups
********************************************************************/



void main(void) 	// main entry point
{
	_DISABLE_COP();

/********************************************************************
*		Initializations
********************************************************************/

SCI0_Init19200();	//19200 baud, 8-bit, 1 stop, no parity, no interrupts

	for (;;)		//endless program loop
	{
/********************************************************************
*		Main Program Code
********************************************************************/

		while(cYes == 'Y')
		{
			cInChar=0;						//NULL initialization for incoming ASCII character
			SCI0_TxString(cClearScreen);	//clean up display
			SCI0_TxString(cStartString);	//display title
			
			SCI0_TxString(cStringA);		//display prompt for first character
			while((cInChar<0x2F)||(cInChar>0x3A))	cInChar=SCI0_RxChar();	//wait for a valid input response
			SCI0_TxChar(cInChar);			//echo valid first character to the screen, beside the prompt
			cSum=ASCIIToHex(cInChar);		//convert to hex, move to hexadecimal summing variable
			 
			cInChar=0;						//NULL incoming ASCII character
			SCI0_TxString(cStringB);		//display prompt for second character
			while((cInChar<0x2F)||(cInChar>0x3A))	cInChar=SCI0_RxChar();	//wait for a valid input response
			SCI0_TxChar(cInChar);			//echo valid second character to screen, beside the prompt
			cSum+=ASCIIToHex(cInChar);		//convert to hex, add to hexadecimal summing variable
			
			SCI0_TxString(cStringX);		//display prompt for result
			cSum=(char)(HexToBCD(cSum));	//convert hexadecimal sum to BCD (cast into a char from int)
			cOut=HexToASCII(cSum>>4);		//prep first of two digits for display
			if(cOut=='0') cOut=' ';			//no leading zero
			SCI0_TxChar(cOut);				//send it out
			SCI0_TxChar(HexToASCII(cSum&0b11111111));	//display the second of two digits, converted to ASCII
			
			SCI0_TxString(cAgainString);	//display prompt for "Again?"
			cYes=0;							//NULL initialization for response
			while((cYes!='Y') && (cYes!='N')) cYes = (char)(SCI0_RxChar());	//wait for y or n converted to uppercase
			SCI0_TxChar(cYes);													//echo to screen
		}
		SCI0_TxString(cGoodbyeString);		//if "no", terminate the program after "goodbye"
		HALT
	}
}
/********************************************************************
*		Functions
********************************************************************/



/********************************************************************
*		Interrupt Service Routines
********************************************************************/



/*******************************************************************/
