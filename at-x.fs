\ galope/at-x.fs
\ Set the cursor at certain column

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017.

\ ==============================================================
\ Licence

\ You may do whatever you want with this work, so long as you
\ retain the copyright/authorship/acknowledgment/credit
\ notice(s) and this license in all redistributed copies and
\ derived works.  There is no warranty.

\ ==============================================================

require ./row.fs

: at-x  ( u -- )  row at-xy  ;
  \ Set the cursor
  \ at the current row (y coordinate)
  \ and the given column (x coordinate).

\ ==============================================================
\ Change log

\ 2012-05-08: Extracted from 'xy.fs'.
\
\ 2012-09-14: Comments edited.
\
\ 2016-01-16: Updated header and layout.
\
\ 2017-08-17: Update change log and header layout.
