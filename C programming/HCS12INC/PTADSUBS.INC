PTADINIT:
    BSET  DDR1AD1, #%11100000
    BCLR  PT1AD1, #%11100000
    BSET  ATD1DIEN1, #%00011111
    CLRA
    RTS