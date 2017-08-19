\ galope/last-column.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: last-column ( -- n ) cols 1- ;

  \ doc{
  \
  \ last-column ( -- n )
  \
  \ _n_ is the number of the last screen column, being zero the first
  \ one.
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
