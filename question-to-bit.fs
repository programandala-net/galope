\ galope/question-to-bit.fs
\ `?>bit`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ ==============================================================

require ./to-bit.fs

: ?>bit ( n -- x ) >bit dup 0= -11 and throw ;
  \ Convert bit number _n_ to its bit mask _x_;
  \ throw error "Result out of range" if result is zero.

\ ==============================================================
\ Change log

\ 2016-07-14: Write.
\
\ 2016-07-19: Fix typo. Update stack notation.
\
\ 2017-08-17: Update change log layout. Update source sytle.
