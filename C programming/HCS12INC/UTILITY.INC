DELAYXMS:
    PSHX
    CPX   #0
    BEQ   DLYXMSEXIT
DLYXMSAGAIN:
    JSR   DELAY1MS
    DEX
    BNE   DLYXMSAGAIN
DLYXMSEXIT:
    PULX
    RTS
DELAY1MS:
    PSHY
    LDY   #2000
DLY1MSAGAIN:
    DEY
    BNE   DLY1MSAGAIN
    PULY
    RTS
