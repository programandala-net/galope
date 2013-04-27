\ galope/at-x.fs
\ Set the cursor at certain colum.

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-08 Extracted from 'xy.fs'.
\ 2012-09-14 Comments edited.

require galope/row.fs

: at-x  ( u -- )
  \ Set the cursor
  \ at the current row (y coordinate)
  \ and the given column (x coordinate).
  row at-xy
  ;
