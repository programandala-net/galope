\ galope/at-y.fs
\ Set the cursor at certain row.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ ==============================================================

require ./column.fs

: at-y  ( u -- )
  column swap at-xy ;
  \ Set the cursor
  \ at the current column (x coordinate)
  \ and the given row (y coordinate).

\ ==============================================================
\ Change log

\ 2012-05-08 Extracted from 'xy.fs'.
\
\ 2012-09-14 Comments edited.
\
\ 2017-08-17: Update change log layout.
