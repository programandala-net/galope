\ galope/two-rolls.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

\ XXX TODO -- Manage requirement of Gforth's `u+do`.

require ./two-roll.fs

: 2rolls ( xd0 xd1 ... xdn n -- xd1 ... xdn xd0 )
  1 u+do i 2roll loop ;

  \ doc{
  \
  \ 2rolls ( xd0 xd1 ... xdn n -- xd1 ... xdn xd0 )
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-04-30 First version.
\
\ 2012-09-14 Renamed to '2rolls' (formerly ' 2mroll').
\
\ 2017-08-19: Update change log layout. Update source style. Fix stack
\ notation. Document.
