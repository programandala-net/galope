\ galope/less-or-equal-or-greater.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

require ./polarity.fs

: <=> ( n1 n2 -- -1|0|1 ) - polarity ;

  \ doc{
  \
  \ <=> ( n1 n2 -- -1|0|1 ) "less-or-equal-or-greater"
  \
  \ If _n1_ equals _n2_, return zero.
  \ If _n1_ is less than _n2_, return negative one.
  \ If _n1_ is greater than _n2_, return positive one.
  \
  \ See: `polarity`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-29: Adapted from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
