/********************************************************************/
// HC12 Program:	YourProg - MiniExplanation
// Processor:		MC9S12XDP512
// Xtal Speed:		16 MHz
// Author:			This B. You
// Date:			LatestRevisionDate

// Details: A more detailed explanation of the program is entered here
/********************************************************************/


#include <hidef.h>      		/* common defines and macros 		*/
#include "derivative.h"      	/* derivative-specific definitions 	*/
#include "SevSeg_Lib.h"
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
unsigned char count = 0;

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
 SevSeg_ButtInit();

	for (;;)
	{
	 // PART ONE
	 // 0b00001000 for left   (LED = 0b10000000) RED
	 // 0b00000001 for middle (LED = 0b01000000) YELLOW
	 // 0b00000010 for right  (LED = 0b00100000) GREEN
  
   // PT1AD1 = 0b00000000;
  	
	 //if (PT1AD1 & 0b00000010)
	 //  PT1AD1 |= 0b00100000;
	 //if (PT1AD1 & 0b00000001)
	 //  PT1AD1 |= 0b01000000;
	 //if (PT1AD1 & 0b00001000)
	 //  PT1AD1 |= 0b10000000;
	
	
	 // PART TWO

	 // if (PT1AD1 & 0b00001000)
	 //   PT1AD1 = 0b10000000;
	 // if (PT1AD1 & 0b00000010)
	 //   PT1AD1 = 0b00100000;
	 
	 
	 // PART THREE
	 // if (P_Debounce())
	 //   {
	 //     count++;
	 //     while (PT1AD1 & 0b00001000);
	 //   }
	 // else if (PT1AD1 & 0b00000001)
	 //   count = 0;
	 // SevSeg_Top4Hex(count);
	 
	 
	 // PART FOUR
	 // if (R_Debounce())
	 //   count++;
	 // if (PT1AD1 & 0b00000001)
	 //   {
	 //     while (PT1AD1 & 0b00001000);
	 //     if (PT1AD1 & 0b00000001)
	 //       count = 0;
	 //   }
	 // SevSeg_Top4Hex(count);
	}

}



/********************************************************************/
//		Functions
/********************************************************************/




/********************************************************************/
//		Interrupt Service Routines
/********************************************************************/

