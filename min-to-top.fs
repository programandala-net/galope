\ galope/min-to-top.fs
\ min>top

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: min>top ( n1 n2 -- n1 n2 | n2 n1 ) 2dup min >r max r> ;

  \ doc{
  \
  \ min>top ( n1 n2 -- n1 n2 | n2 n1 )
  \
  \ Make sure the top of stack is the lesser of _n1_ and _n2_.
  \
  \ See: `max>top`, `pair=`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-11: Start.


