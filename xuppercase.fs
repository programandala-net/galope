\ galope/xuppercase.fs
\ 'xuppercase'
\ Convert a UTF-8 string to uppercase.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ 2012-12-02 First version.
\ 2013-08-27 Changed the stack notation.

require ./xbounds.fs
require ./xcase.fs
require ./x-c-store.fs

: xuppercase  ( xca len -- )
  \ Convert a UTF-8 string to uppercase.
  xbounds ?do
    dup >r xc@+ dup xlower? if  xtoupper r> xc!  else  drop rdrop  then
  loop  drop
  ;
