\ galope/xlowercase.fs
\ 'xlowercase'
\ Convert a UTF-8 string to lowercase.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2016.

\ ==============================================================

require ./xbounds.fs
require ./xcase.fs
require ./x-c-store.fs

: xlowercase  ( xca len -- )
  xbounds ?do
    dup >r xc@+ dup xupper? if  xtolower r> xc!  else  drop rdrop  then
  loop  drop  ;
  \ Convert a UTF-8 string to lowercase.

\ ==============================================================
\ History

\ 2012-12-02: First version.
\
\ 2013-08-27: Update the stack notation.
\
\ 2016-06-27: Update the header and the source style.
\
\ 2016-07-11: Update source layout.
