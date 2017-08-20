\ galope/dollar-empty.fs
\ $empty

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require string.fs  \ Gforth's dynamic strings

: $empty ( a -- ) 0 swap $!len ;
  \ Empty a dynamic string variable.

\ ==============================================================
\ Change log

\ 2013-11-11 Added.
\
\ 2017-08-17: Update change log layout and source style.

