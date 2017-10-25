\ galope/at-x.fs
\ Set the cursor at certain column

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017.

\ ==============================================================

require ./row.fs

: at-x ( u -- ) row at-xy ;

  \ doc{
  \
  \ at-x ( u -- )
  \
  \ Set the cursor at column _u_ (x coordinate) of the current row (y
  \ coordinate).
  \
  \ See: `at-y`, `home`, `row`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-08: Extracted from 'xy.fs'.
\
\ 2012-09-14: Comments edited.
\
\ 2016-01-16: Updated header and layout.
\
\ 2017-08-17: Update change log and header layout.
\
\ 2017-10-24: Improve documentation.
\
\ 2017-10-25: Improve documentation.
