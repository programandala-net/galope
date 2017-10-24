\ galope/at-y.fs
\ Set the cursor at certain row.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require ./column.fs

: at-y ( u -- ) column swap at-xy ;

  \ doc{
  \
  \ at-y ( u -- )
  \
  \ Set the cursor at the current column (x coordinate) and row _u_ (y
  \ coordinate).
  \
  \ See: `at-x`, `column`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-08 Extracted from 'xy.fs'.
\
\ 2012-09-14 Comments edited.
\
\ 2017-08-17: Update change log layout.
\
\ 2017-10-24: Improve documentation.
