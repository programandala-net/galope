\ galope/minus-cell-bounds.fs
\ -cell-bounds

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ 2014-11-09: Added. Based on <galope/minus-bounds.fs>.  This word was
\ required to explore a cells table backwards.

require ./minus-bounds.fs

: -cell-bounds  ( a1 len -- a2 a1 )
  \ Convert an address and length to the parameters needed by a
  \ "do ... cell negate +loop" in order to examine that memory zone in
  \ reverse order.
  \ len = length in address units
  1+ -bounds cell -
  ;

