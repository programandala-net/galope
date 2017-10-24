\ galope/possibly.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Taken from Wil Baden's ToolBelt 2002.

\ ==============================================================

: possibly ( "name" -- )
  bl word find ?dup and if execute then ;

  \ doc{
  \
  \ possibly ( "name -- )
  \
  \ If word _name_ exists, execute it; otherwise, do nothing.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-18 Added.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-10-24: Improve documentation.
