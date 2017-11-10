\ galope/x-uppercase.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require ./xbounds.fs
require ./x-c-store.fs
require ./x-lower-question.fs
require ./x-to-upper.fs

: xuppercase ( xca len -- )
  xbounds ?do
    dup >r xc@+ dup xlower? if   xtoupper r> xc!
                            else drop rdrop then
  loop drop ;

  \ doc{
  \
  \ xuppercase ( xca len -- )
  \
  \ Convert the UTF-8 character string _xca len_ to uppercase.
  \
  \ See: `xlowercase`, `xtitlecase`, `xcapitalize`, `xtoupper`.
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
\
\ 2017-11-08: Update requirements.
\
\ 2017-11-09: Rename the module after current convention.
\
\ 2017-11-10: Improve documentation.
