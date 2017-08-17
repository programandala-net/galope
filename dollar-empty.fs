\ galope/dollar-empty.fs
\ $empty

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-11-11 Added.

require string.fs  \ Gforth's dynamic strings

: $empty  ( a -- )
  \ Empty a dynamic string variable.
  0 swap $!len
  ;

