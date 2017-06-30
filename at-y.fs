\ galope/at-y.fs
\ Set the cursor at certain row.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-08 Extracted from 'xy.fs'.
\ 2012-09-14 Comments edited.

require ./column.fs

: at-y  ( u -- )
  \ Set the cursor
  \ at the current column (x coordinate)
  \ and the given row (y coordinate).
  column swap at-xy
  ;

