\ galope/third.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Code from Wil Baden's ToolBelt 2002.

\ ==============================================================

: third ( x1 x2 x3 -- x1 x2 x3 x1 ) 2 pick ;

  \ doc{
  \
  \ third ( x1 x2 x3 -- x1 x2 x3 x1 )
  \
  \ Copy third element on the stack onto top of stack.
  \
  \ See: `fourth`, `3dup`, `3drop`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-12-04 Added.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-10-26: Improve documentation.
