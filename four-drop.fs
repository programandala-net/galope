\ galope/four-drop.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: 4drop ( x1 x2 x3 x4 -- ) 2drop 2drop ;

  \ doc{
  \
  \ 4drop ( x1 x2 x3 x4 -- )
  \
  \ Remove cells _x1 x2 x3 x4_ from the stack.
  \
  \ See: `3drop`, `fourth`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-01-04 Added.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-10-26: Improve documentation.
