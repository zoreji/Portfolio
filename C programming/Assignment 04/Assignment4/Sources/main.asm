;************************************************************************
;* HC12 Program:	Lab 01							*
;* Processor:	MC9S12XDP512											*
;* Xtal Speed:	16 MHz													*
;* Author:		Brennan MacGregor											*
;* Date:		September 17th, 2015										*
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

    BSET    DDR1AD1,#%11100000
    BCLR    PT1AD1,#%11100000
    BSET    ATD1DIEN1,#%00011111
    CLRA
AGAINC:
    STAA    PT1AD1
    CLRB
    BRSET   PT1AD1, #%00000001,CENTREBUTTONPRESS
AGAINR:
    BRSET   PT1AD1, #%00000010,RIGHTBUTTONPRESS   ;2
AGAINB:
    BRSET   PT1AD1, #%00000100,BOTTOMBUTTONPRESS
AGAINL:
    BRSET   PT1AD1, #%00001000,LEFTBUTTONPRESS    ;8
AGAINT:
    BRSET   PT1AD1, #%00010000,TOPBUTTONPRESS
LOADCOUNT:
    LDX     #5
DISPLAY:
    LSLB
    DBNE    X, DISPLAY
    TBA
    BRA     AGAINC
    
CENTREBUTTONPRESS:
    INCB
    BRA     AGAINR
RIGHTBUTTONPRESS:
    INCB
    BRA     AGAINB
BOTTOMBUTTONPRESS:
    INCB
    BRA     AGAINL
LEFTBUTTONPRESS:
    INCB
    BRA     AGAINT
TOPBUTTONPRESS:
    INCB
    BRA     LOADCOUNT

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
 INCLUDE  "PTADSUBS.INC"

;********************************************************************
;*		Interrupt Vectors											*
;********************************************************************

		ORG			$FFFE
		DC.W		Entry			;Reset Vector
