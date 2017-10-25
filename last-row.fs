\ galope/last-row.fs
\ Last screen row

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2015, 2017

\ ==============================================================

: last-row ( -- u ) rows 1- ;

  \ doc{
  \
  \ last-row ( -- u )
  \
  \ Return the last row _u_ (Y coordinate) of the screen, being zero
  \ the first one.
  \
  \ See: `last-column`, `row`.
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
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-10-25: Improve documentation.
