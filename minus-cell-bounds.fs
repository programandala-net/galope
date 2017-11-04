\ galope/minus-cell-bounds.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./minus-bounds.fs

: -cell-bounds ( a1 len1 -- a1 a2 ) 1+ -bounds cell - ;

  \ doc{
  \
  \ -cell-bounds ( a1 len1 -- a1 a2 )
  \
  \ Convert memory zone _a1 len1_, being _len_ the length in address
  \ units, to the parameters _a1 a2_ needed by a ``do ... cell negate
  \ +loop``, being _a2_ the address of the last cell of the memory
  \ zone, in order to examine that string in reverse order, cell by
  \ cell.
  \
  \ See: `-bounds`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-11-09: Added. Based on <galope/minus-bounds.fs>.  This word was
\ required to explore a cells table backwards.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-11-03: Improve documentation.
