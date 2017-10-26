\ galope/three-drop.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

: 3drop ( x1 x2 x3 -- ) 2drop drop ;

  \ doc{
  \
  \ 3drop ( x1 x2 x3 -- )
  \
  \ Remove cells _x1 x2 x3_ from the stack.
  \
  \ See: `4drop`, `3dup`, `third`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-12-04 Added.
\
\ 2017-08-17: Update change log layout. Update header and source
\ style.
\
\ 2017-10-26: Improve documentation.
