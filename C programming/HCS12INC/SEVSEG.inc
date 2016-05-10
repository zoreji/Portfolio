;****************************************************************** 
;* Title:         Seven Segment Controller Library 
;* Processor:     MC9S12XDP512 
;* Xtal Speed:    16 MHz 
;* Author:        This B. You 
;* Date:          Now 
;* 
;* Contains:      SevSeg_Init 
;*   SevSeg_Char 
;*   SevSeg_dChar 
;*   SevSeg_BlChar 
;*   SevSeg_BlAll 
;*   SevSeg_Top4 
;*   SevSeg_Bot4 
;* 
;****************************************************************** 
SevSeg_Init:
    BSET    PORTA, %00000011  ; resting state, mode and /write HIGH
    BSET    DDRA, %00000011   ; make A1 (mode) and A0 (/write) outputs
    
    MOVB    #%11111111, PORTB ; set all PORTB HIGH
    MOVB    #%11111111, DDRB  ; make all PORTB outputs
    
    ;JSR      SevSeg_B1A11
    
    RTS

;****************************************************************** 
;*   SevSeg_Char 
;* 
;* Regs affected: none 
;* 
;* Accepts a hex character in Accu,mulator A and
;* a location (0 to 7) in Accumulator B and places the character
;*
;* The routine expects the user to know the device limits,
;* and assumes that SevSeg_Init has been run already.
;*
;****************************************************************** 
SevSeg_Char:
    PSHA
    PSHB
    
    ANDB  #%00000111        ; clean up address - only these bits valid
    ORAB  #%01011000        ; add control: hex, decode, no SD, Bank A
    ;       ||||||||
    ;       ||||||| ----\
    ;       |||||| ------\  don't mess with the addresses
    ;       ||||| -------/
    ;       |||| --------memory bank A
    ;       ||| ---------not shutdown
    ;       || ----------decode mode
    ;       | -----------Hexadecimal Decoding
    ;        ------------'No data coming' means single digit mode
    
    ANDA  #%00001111        ; prep the data digit: clear upper nibble
    ORAA  #%10000000        ; no decimal point
    
    STAB  PORTB             ; control byte placed on the data bus
    BCLR  PORTA, %00000001  ; node still high (control) /write low
    BSET  PORTA, %00000011  ; resting state: mode and /write HIGH
    
    STAA  PORTB             ; data byte placed on the data bus
    BCLR  PORTA, %00000011  ; node low (data), /write low
    BSET  PORTA, %00000011  ; resting state: mode and /write HIGH
    
    PULB
    PULA
    RTS

;****************************************************************** 
;*   SevSeg_BlChar 
;* 
;* Regs affected: none 
;* 
;* Accepts a location (0 to 7) in Accumulator B and blanks that 
;* location using “No Decode” mode and individual segment control. 
;* 
;****************************************************************** 
SevSeg_BlChar:
    PSHA
    PSHB
    
    ANDB  #%00000111
    ORAB  #%00111000    ; control
    
    CLRA
    ORAA  #%10000000
    
    STAB  PORTB
    BCLR  PORTA, %00000001
    BSET  PORTA, %00000011
    
    STAA  PORTB
    BCLR  PORTA, %00000011
    BSET  PORTA, %00000011
    
    PULB
    PULA
    RTS

;****************************************************************** 
;*   SevSeg_BlAll 
;* 
;* Regs affected: none 
;* 
;* Blanks all eight digits using SevSeg_BlChar in a loop 
;* 
;****************************************************************** 
SevSeg_BlAll:
    PSHA
    PSHB
    
    CLRA
    ORAA  #%10000000
    
    STAB  PORTB
    BCLR  PORTA, %00000001
    BSET  PORTA, %00000011
    
    PULB
    PULA
    RTS

;****************************************************************** 
;*   SevSeg_dChar 
;* 
;* Regs affected: none 
;* 
;* Accepts a hex character in Accumulator A and a location (0 to 7) 
;* in Accumulator B and places the character, with the decimal 
;* point displayed, in that location. 
;* 
;* The routine expects the user to know the LED limits, 
;* and assumes that SevSeg_Init has been run already. 
;* 
;****************************************************************** 
SevSeg_dChar:
    PSHA
    PSHB
    
    ANDB  #%00000111
    ORAB  #%01011000
    
    ANDA  #%00001111
    
    STAB  PORTB
    BCLR  PORTA, %00000001
    BSET  PORTA, %00000011
    
    STAA  PORTB           
    BCLR  PORTA, %00000011
    BSET  PORTA, %00000011
    
    PULB
    PULA
    RTS

;****************************************************************** 
;*   SevSeg_Top4 
;* 
;* Regs affected: none 
;* 
;* Accepts four hex nibbles in Accumulator D and 
;* writes them to locations 0 to 3 (upper red seven segment bar) 
;* 
;* Relies on SevSeg_Char 
;* 
;****************************************************************** 
SevSeg_Top4:
    
    PSHD
    PSHB
    
    LDAB  #$0    ; character one, spot zero
    
    PSHA
    LSRA
    LSRA
    LSRA
    LSRA
    JSR   SevSeg_Char
    PULA
    
    LDAB  #$1    ; character two, spot one
    JSR   SevSeg_Char
    PULB
    
    TBA
                 ; character three, spot two
    PSHB  
    LDAB  #$2
    
    PSHA
    LSRA
    LSRA
    LSRA
    LSRA
    JSR   SevSeg_Char
    PULA
                 
    LDAB  #$3    ; character four, spot three
    JSR   SevSeg_Char
        
    PULB
    PULD
    RTS

;****************************************************************** 
;*   SevSeg_Bot4 
;* 
;* Regs affected: none 
;* 
;* Accepts four hex nibbles in Accumulator D and 
;* writes them to locations 4 to 7 (lower yellow seven segment bar 
;* 
;* Relies on SevSeg_Char 
;* 
;****************************************************************** 
SevSeg_Bot4:
    
    PSHD
    PSHB
    
    LDAB  #$4    ; character one, spot four
    
    PSHA
    LSRA
    LSRA
    LSRA
    LSRA
    JSR   SevSeg_Char
    PULA
    
    LDAB  #$5    ; character two, spot five
    JSR   SevSeg_Char
    PULB
    
    TBA
                 ; character three, spot six
    PSHB  
    LDAB  #$6
    
    PSHA
    LSRA
    LSRA
    LSRA
    LSRA
    JSR   SevSeg_Char
    PULA
                 
    LDAB  #$7    ; character four, spot seven
    JSR   SevSeg_Char
        
    PULB
    PULD
    RTS

;****************************************************************** 
;*   SevSeg_Cust 
;* 
;* Regs affected: none 
;* 
;* Accepts a custom character in Accumulator A and a location (0 to 7) 
;* in Accumulator B and places the character using “No Decode” mode. 
;* 
;* The routine expects the user to know the LED segments. 
;* 
;******************************************************************
SevSeg_Cust:
    PSHA
    PSHB
    
    ANDB  #%00000111        ; clean up address - only these bits valid
    ORAB  #%01111000        ; add control: no hex, no decode, no SD, Bank A
    ;       ||||||||
    ;       ||||||| ----\
    ;       |||||| ------\  don't mess with the addresses
    ;       ||||| -------/
    ;       |||| --------memory bank A
    ;       ||| ---------not shutdown
    ;       || ----------decode mode
    ;       | -----------Hexadecimal Decoding
    ;        ------------'No data coming' means single digit mode
    
    
    STAB  PORTB             ; control byte placed on the data bus
    BCLR  PORTA, #%00000001  ; node still high (control) /write low
    BSET  PORTA, #%00000011  ; resting state: mode and /write HIGH
    
    STAA  PORTB             ; data byte placed on the data bus
    BCLR  PORTA, #%00000011  ; node low (data), /write low
    BSET  PORTA, #%00000011  ; resting state: mode and /write HIGH
    
    PULB
    PULA
    RTS