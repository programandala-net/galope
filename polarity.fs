\ galope/polarity.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

: polarity ( n -- -1|0|1 ) -1 max 1 min ;

  \ doc{
  \
  \ polarity ( n -- -1|0|1 )
  \
  \ If _n_ is zero, return zero.
  \ If _n_ is negative, return negative one.
  \ If _n_ is positive, return positive one.

  \ See: `<=>`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-29: Adapted from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
