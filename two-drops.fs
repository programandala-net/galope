\ galope/two-drops.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require ./drops.fs

: 2drops ( xd#1 ... xd#n n -- ) 2* drops ;

  \ doc{
  \
  \ 2drops ( xd#1 ... xd#n n -- )
  \
  \ Remove _n_ double-cell items from the stack.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-04-30 Extracted from mdrop.fs.
\
\ 2012-09-14 Renamed to '2drops'.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-11-05: Improve documentation.
