\ galope/max-to-top.fs
\ max>top

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: max>top ( n1 n2 -- n1 n2 | n2 n1 ) 2dup max >r min r> ;

  \ doc{
  \
  \ max>top ( n1 n2 -- n1 n2 | n2 n1 )
  \
  \ Make sure the top of stack is the greater of _n1_ and _n2_.
  \
  \ See: `min>top`, `pair=`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-11: Start.



