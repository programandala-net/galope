\ galope/two-array-to.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

: 2array> ( n a1 -- a2 ) swap [ 2 cells ] literal * + ;

  \ doc{
  \
  \ 2array> ( n a1 -- a2 ) "two-array-to"
  \
  \ Return address _a2_ of element _n_ of a 1-dimension
  \ double-cell array _a1_.  ``2array>`` is a common factor of
  \ `2avalue` and `2avariable`.
  \
  \ See: `2array<`, `array>`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-05-01: Start. Adapt from Solo Forth
\ (http://programanadala.net/en.program.solo_forth.html).
