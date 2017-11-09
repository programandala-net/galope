\ galope/x-lowercase.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2016, 2017.

\ ==============================================================

require ./xbounds.fs
require ./x-c-store.fs
require ./x-to-lower.fs
require ./x-upper-question.fs

: xlowercase ( xca len -- )
  xbounds ?do
    dup >r xc@+ dup xupper? if   xtolower r> xc!
                            else drop rdrop then
  loop drop ;
  \ Convert a UTF-8 string to lowercase.

\ ==============================================================
\ Change log

\ 2012-12-02: First version.
\
\ 2013-08-27: Update the stack notation.
\
\ 2016-06-27: Update the header and the source style.
\
\ 2016-07-11: Update source layout.
\
\ 2017-11-08: Update requirements and source layout.
\
\ 2017-11-09: Rename the module after current convention.
