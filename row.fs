\ galope/row.fs
\ Current row (y coordinate)

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-08 Extracted from 'xy.fs'.

require ./xy.fs

: row  ( -- u )
  xy nip
  ;

