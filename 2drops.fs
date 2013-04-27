\ galope/2drops.fs
\ Double multiple drop

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History

\ 2012-04-30 Extracted from mdrop.fs.
\ 2012-09-14 Renamed to '2drops'.

require galope/drops.fs

: 2drops ( d1 ... dn n -- )
  2* drops
  ;

