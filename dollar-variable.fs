\ galope/dollar-variable.fs
\ $variable

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2015.

\ 2013-11-09: Added.
\ 2015-04-15: Simpler.

require string.fs  \ Gforth's dynamic strings

: $variable  ( "name" -- )
  \ Create and initialize a dynamic string variable.
  \ variable  pad 0 latestxt execute $!  \ XXX OLD
  variable  0 latestxt execute $!len
  ;
