;************************************************************************
;* HC12 Program:	Assignment 4.2							*
;* Processor:	MC9S12XDP512											*
;* Xtal Speed:	16 MHz													*
;* Author:		Brennan MacGregor											*
;* Date:		September 17, 2015										*
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
     JSR SevSeg_Init
     
     ;LDAA #$A           ; letter to write
     ;LDAB #%00000000    ; spot to write in
     
     ;JSR SevSeg_Char
     
     ;JSR SevSeg_BlChar
     
     ;JSR SevSeg_BlAll
     
     ;LDAA #$A
     ;LDAB #%00000000
     ;JSR SevSeg_dChar
     
     ;CLRA
     ;CLRB
     ;LDD  #$ABCD
     ;JSR SevSeg_Top4
     
     ;CLRA
     ;CLRB
     ;LDD  #$EF01
     ;JSR  SevSeg_Bot4
     
     ;JSR  SevSeg_BlAll
     
     ;CLRA
     ;CLRB
     
     ;LDAA #%11110001
     ;LDAB #%00000000
     ;JSR  SevSeg_Cust
     
     LDD  #$8AE3
     JSR  SevSeg_Top4
     
     LDD  #$2A05
     JSR  SevSeg_Bot4
     
     LDAA #%01101101
     LDAB #$4
     JSR  SevSeg_Cust
     
     LDAA #%01100011
     LDAB #$6
     JSR  SevSeg_Cust
     
     BRA  *
    
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
		INCLUDE SEVSEG.inc


;********************************************************************
;*		Interrupt Vectors											*
;********************************************************************

		ORG			$FFFE
		DC.W		Entry			;Reset Vector
