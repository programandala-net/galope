\ galope/dollar-variable.fs
\ $variable

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-11-09 Added.

require string.fs  \ Gforth's dynamic strings

: $variable  ( "name" -- )
  \ Create and initialize a dynamic string variable.
  variable  pad 0 latestxt execute $!
  ;
