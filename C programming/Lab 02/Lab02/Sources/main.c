/********************************************************************/
// HC12 Program:	Lab 02
// Processor:		MC9S12XDP512
// Xtal Speed:		16 MHz
// Author:			Brennan MacGregor
// Date:			October 7th, 2015

// Details: A more detailed explanation of the program is entered here
/********************************************************************/


#include  <hidef.h>      		/* common defines and macros 		*/
#include  "derivative.h"      	/* derivative-specific definitions 	*/
#include  "my_Lib.h"
/********************************************************************/
//		Library includes
/********************************************************************/

//#include "Your_Lib.h"


/********************************************************************/
//		Prototypes
/********************************************************************/


/********************************************************************/
//		Variables
/********************************************************************/


/********************************************************************/
//		Lookups
/********************************************************************/


void main(void)
{
// main entry point
_DISABLE_COP();

/********************************************************************/
// initializations
/********************************************************************/
  SevSeg_Init();
  SevSeg_BlAll();
  SevSeg_dChar(0, 0);
  SevSeg_Top4(1234);
  SevSeg_Bot4(9621);
  //SevSeg_Cuty(0, 0b01110001);
  
  //SevSeg_Cuty(0, 0b00011111);
  //SevSeg_BlChar(1);
  //SevSeg_Cuty(2, 0b00111011);
  //SevSeg_dChar(3, 1);
  //SevSeg_Cuty(4, 0b01111110);
  //SevSeg_Char(5, 2);
  SevSeg_Char(6, 0xA);
  //SevSeg_Char(7, 0);

	for (;;)
	{
	//main program loop
	
	}

}



/********************************************************************/
//		Functions
/********************************************************************/




/********************************************************************/
//		Interrupt Service Routines
/********************************************************************/

