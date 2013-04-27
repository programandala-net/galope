\ galope/xuppercase.fs
\ 'xuppercase'
\ Convert a UTF-8 string to uppercase.

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-12-02 First version.

require galope/xbounds.fs
require galope/xcase.fs
require galope/x-c-store.fs

: xuppercase  ( a u -- )
  \ Convert a UTF-8 string to uppercase.
  xbounds ?do
    dup >r xc@+ dup xlower? if  xtoupper r> xc!  else  drop rdrop  then
  loop  drop
  ;
