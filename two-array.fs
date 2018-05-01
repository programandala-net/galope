\ galope/two-array.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./two-array-to.fs

: 2array ( n "name" -- )
  create [ 2 cells ] literal * allot
  does> ( n -- a ) ( n dfa ) 2array> ;

  \ doc{
  \
  \ 2array ( n "name" -- )
  \
  \ Create a 1-dimension double-cell array _name_ with _n_ elements
  \ and the execution semantics defined below.
  \
  \ _name_ execution:
  \
  \ ----
  \ name ( n -- a )
  \ ----
  \
  \ Return address _a_ of element _n_.
  \
  \ See: `2arrayed`, `2array>`, `strings:`, `array`
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-08-16: Start. Adapt from Solo Forth's `2avariable`
\ (http://programandala.net/en.program.solo_forth.html).
\
\ 2017-10-24: Update documentation markup.
\
\ 2017-11-05: Improve documentation.
\
\ 2018-05-01: Use `2array>`.
