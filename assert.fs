\ galope/assert.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author:
\   Brad Nelson
\   From Literate Forth
\   http://bradn123.github.io/literateforth/out/literate_0012.html

\ ==============================================================

: assert ( n -- ) 0= if abort then ;

  \ doc{
  \
  \ assert ( n -- )
  \
  \ If _n_ is zero, ``abort``; otherwise do nothing.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-05 Added.
\
\ 2017-08-17: Update change log and header layout. Update source
\ style.
\
\ 2017-10-24: Improve documentation.
