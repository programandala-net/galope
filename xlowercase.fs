\ galope/xlowercase.fs
\ 'xlowercase'
\ Convert a UTF-8 string to lowercase.

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-12-02 First version.
\ 2013-08-27 Changed the stack notation.

require ./xbounds.fs
require ./xcase.fs
require ./x-c-store.fs

: xlowercase  ( xca len -- )
  \ Convert a UTF-8 string to lowercase.
  xbounds ?do
    dup >r xc@+ dup xupper? if  xtolower r> xc!  else  drop rdrop  then
  loop  drop
  ;

