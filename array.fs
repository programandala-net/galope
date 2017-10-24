\ galope/array.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

: array ( n "name" -- )
  create cells allot
  does> ( n -- a ) ( n dfa ) swap cells + ;

  \ doc{
  \
  \ array ( n "name" -- )
  \
  \ Create a 1-dimension single-cell array _name_ with _n_ elements
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
  \ See: `2array`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-08-16: Start. Adapt from Solo Forth's `avariable`
\ (http://programandala.net/en.program.solo_forth.html).
\
\ 2017-10-24: Update documentation markup.
