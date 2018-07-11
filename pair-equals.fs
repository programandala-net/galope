\ galope/pair-equals.fs
\ pair=

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

require ./max-to-top.fs

: pair= ( x1 x2 x3 x4 -- f ) 2>r max>top 2r> max>top d= ;

  \ doc{
  \
  \ pair= ( x1 x2 x3 x4 -- f )
  \
  \ _f_ is true if and only if _x1 x2_ is the same pair as _x3 x4_,
  \ i.e. both components of the each pair are in the other pair, no
  \ matter the order.
  \
  \ See: `str<>`, `min>top`, `max>top`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-11: Start.

