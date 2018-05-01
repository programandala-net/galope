\ galope/array-from.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

: array< ( a1 n -- a2 ) cells + ;

  \ doc{
  \
  \ array< ( a1 n -- a2 ) "array-from"
  \
  \ Return address _a2_ of element _n_ of a 1-dimension
  \ cell array _a1_.
  \
  \ See: `2array<`, `array>`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-05-01: Start. Adapt from Solo Forth
\ (http://programanadala.net/en.program.solo_forth.html).
