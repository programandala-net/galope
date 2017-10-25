\ galope/column.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017

\ ==============================================================

require ./xy.fs

: column ( -- u ) xy drop ;

  \ doc{
  \
  \ column ( -- u )
  \
  \ Return the current column _u_ (X coordinate).
  \
  \ See: `row`, `xy`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-08: Extracted from 'xy.fs'.
\
\ 2012-09-14: Code reformated.
\
\ 2016-01-16: Updated header and layout.
\
\ 2017-08-17: Update change log layout.
\
\ 2017-10-25: Improve documentation.
