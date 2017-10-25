\ galope/last-column.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2015, 2017

\ ==============================================================

: last-column ( -- n ) cols 1- ;

  \ doc{
  \
  \ last-column ( -- u )
  \
  \ Return the last column _u_ (X coordinate) of the screen, being
  \ zero the first one.
  \
  \ See: `last-row`, `column`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-08: Extracted from an application of the author.
\
\ 2012-09-14: Code reformated.
\
\ 2015-10-13: Renamed.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-08-19: Fix: Replace `columns` with `cols`.
\
\ 2017-10-25: Improve documentation.
