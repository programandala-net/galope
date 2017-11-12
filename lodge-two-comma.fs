\ galope/lodge-two-comma.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge.fs
require ./lodge-allot.fs
require ./lodge-here.fs

: lodge-2, ( x1 x2 -- )
  lodge-here [ 2 cells ] literal lodge-allot lodge+ 2! ;

  \ doc{
  \
  \ lodge-2, ( x1 x2 -- )
  \
  \ Add the cell pair _x1 x2_ to the `lodge` increasing its
  \ size by two cells.
  \
  \ See: `lodge-,`, `lodge-save-mem`, `lodge-here`,
  \ `lodge-allot`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>.
