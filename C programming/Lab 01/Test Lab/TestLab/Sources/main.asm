;************************************************************************
;* HC12 Program:								*
;* Processor:	MC9S12XDP512											*
;* Xtal Speed:	16 MHz													*
;* Author:  Brennan MacGregor											*
;* Date:												*
;*																		*
;* Details: 	
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
    BRSET   PT1AD1, #%00000001,CENTREBUTTONPRESS     ; check to see if PT1AD1 is equal to 0000 0001
AGAINR:
    BRSET   PT1AD1, #%00000010,RIGHTBUTTONPRESS      ; as above, but 0000 0010
AGAINB:
    BRSET   PT1AD1, #%00000100,BOTTOMBUTTONPRESS     ; as above, but 0000 0100
AGAINL:
    BRSET   PT1AD1, #%00001000,LEFTBUTTONPRESS       ; as above, but 0000 1000
AGAINT:
    BRSET   PT1AD1, #%00010000,TOPBUTTONPRESS        ; as above, but 0001 0000
LOADCOUNT:
    LDX     #5                                       ; load x with 5.  This is used as a counter
DISPLAY:
    LSLB                                             ; left shift b register
    DBNE    X, DISPLAY                               ; if x != 0, return to display
    TBA                                              ; put accb into acca
    BRA     AGAINC                                   ; if x != 0, repeat
    
CENTREBUTTONPRESS:                                   ; if we;ve pressed the middle button...
    INCB                                             ; ...increment b...
    BRA     AGAINR                                   ; ...and check if the right button is down
RIGHTBUTTONPRESS:
    INCB                                             ; as above, but then check bottom button
    BRA     AGAINB
BOTTOMBUTTONPRESS:
    INCB                                             ; as above, but then check left button
    BRA     AGAINL
LEFTBUTTONPRESS:                                     ; as above, but then check top button
    INCB
    BRA     AGAINT
TOPBUTTONPRESS:                                      ; we've checked everything - return to loadcount
    INCB                                             ; this creates a closed system (read: INFINITE LOOP)
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


;********************************************************************
;*		Interrupt Vectors											*
;********************************************************************

		ORG			$FFFE
		DC.W		Entry			;Reset Vector
