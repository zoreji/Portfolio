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
unsigned int clockCount = 0;
unsigned int oneHundred = 0;
unsigned int hexCount = 0;

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
	   oneHundred++;
	   if (oneHundred / 100 > 1)
	    {
	      clockCount++;
	      oneHundred = 0;
	    }
	    
	    SevSeg_Top4(clockCount);
	    
	    if (P_Debounce())
	      {
	      if (PT1AD1 & 0b00010000)
	        hexCount++;
	      if (PT1AD1 & 0b00000100)          hexCount--;
	    
	      SevSeg_Bot4Hex(hexCount);
	    
	      if (PT1AD1 & 0b00000001)
	        {
	          hexCount = 0;
	          clockCount = 0;
	          oneHundred = 0;
	          SevSeg_BlAll();
	          SevSeg_Bot4(0000);
	        }
	    
	      }
	}

}



/********************************************************************/
//		Functions
/********************************************************************/




/********************************************************************/
//		Interrupt Service Routines
/********************************************************************/