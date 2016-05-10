;************************************************************************
;* HC12 Program:	Assignment 3							*
;* Processor:	MC9S12XDP512											*
;* Xtal Speed:	16 MHz													*
;* Author:		Brennan MacGregor											*
;* Date:		September 10, 2015										*
;*																		*
;* Details: A more detailed explanation of the program is entered here	*
;*																		*
;************************************************************************

;export symbols
		XDEF 		Entry			;export'Entry' symbol
		ABSENTRY 	Entry			;for absolute assembly: app entry point

;include derivative specific macros
		INCLUDE 'derivative.inc'

;********************************************************************
;*		Equates														*
;********************************************************************


;********************************************************************
;*		Variables													*
;********************************************************************
		ORG			RAMStart		;Address $2000


;********************************************************************
;*		Code Section												*
;********************************************************************
		ORG			ROM_4000Start	;Address $4000 (FLASH)
Entry:
		LDS			#RAMEnd+1		;initialize the stack pointer

Main:
    BSET    DDR1AD1, #%11100000
    BCLR    PT1AD1, #%11100000
    BSET    ATD1DIEN1, #%00011111
    CLRA
    LDAA    #%00000000
    
AGAIN:
    STAA    PT1AD1
    BRSET   PT1AD1, #%00000010, RIGHTPRESS
    BRSET   PT1AD1, #%00001000, LEFTPRESS
    BRA     AGAIN
RIGHTPRESS:
    LDAA    #%00100000
    BRA     AGAIN
LEFTPRESS:
    LDAA    #%10000000
    BRA     AGAIN
    
;   LDX     #500
;DELAYXMS:
;   LDY     #2000
;DELAY1MS:
;   DEY
;   BNE     DELAY1MS
;   DEX
;   BNE     DELAYXMS
;   BRCLR   PT1AD1, #%00000001, MIDBTNUP
;   ADDA    #%11100000
;   BRA     AGAIN
;MIDBTNUP:
;   ADDA    #%00100000
;   BRA     AGAIN
                 
;********************************************************************
;*		Subroutines													*
;********************************************************************


;********************************************************************
;*		Interrupt Service Routines											*
;********************************************************************


;********************************************************************
;*		Constants													*
;********************************************************************
		ORG			ROM_C000Start	;second block of ROM


;********************************************************************
;*		Look-Up Tables												*
;********************************************************************


;********************************************************************
;*		SCI VT100 Strings											*
;********************************************************************


;********************************************************************
;*		Absolute Library Includes									*
;********************************************************************

		;INCLUDE "Your_Lib.inc"


;********************************************************************
;*		Interrupt Vectors											*
;********************************************************************

		ORG			$FFFE
		DC.W		Entry			;Reset Vector
