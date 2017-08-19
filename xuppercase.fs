\ galope/xuppercase.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require ./xbounds.fs
require ./xcase.fs
require ./x-c-store.fs

: xuppercase ( xca len -- )
  xbounds ?do
    dup >r xc@+ dup xlower? if   xtoupper r> xc!
                            else drop rdrop then
  loop drop ;

  \ doc{
  \
  \ xuppercase ( xca len -- )
  \
  \ Convert a UTF-8 string _xca len_ to uppercase.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-12-02 First version.
\
\ 2013-08-27 Changed the stack notation.
\
\ 2017-08-19: Update change log layout. Update source style.
\ Document.
