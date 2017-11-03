\ galope/d-to-str.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2015, 2017.

\ ==============================================================

: d>str ( d -- ca len ) tuck dabs <# #s rot sign #> ;

  \ doc{
  \
  \ d>str ( d -- ca len )
  \
  \ Convert _d_ to string _ca len_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-11-26: First version.
\
\ 2015-10-14: Fixed: sign was missing. File renamed.
\
\ 2017-08-17: Update change log layout and source style. Remove
\ optional definition of `tuck`. Update header.
\
\ 2017-11-03: Fix stack notation. Improve documentation.
