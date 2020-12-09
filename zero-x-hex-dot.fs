\ galope/zero-x-hex-dot.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2020

\ ==============================================================

: 0xhex. ( u -- )
  ." 0x" base @ swap hex u. base ! ;

  \ doc{
  \
  \ 0xhex. ( u -- )
  \
  \ Display _u_ as an unsigned hex number, prefixed with "0x" and
  \ followed by a space.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2020-12-08: Code modified from Gforth's `hex.`.
