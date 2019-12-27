\ n-two-comma.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ By Marcos Cruz (programandala.net), 2017, 2019.

\ ==============================================================

: n2, ( xd#1 .. xd#n n -- ) 0 ?do 2, loop ;

  \ doc{
  \
  \ n2, ( xd#1 .. xd#n n -- )
  \
  \ Execute ``2,`` _n_ times.
  \
  \ See: `n,`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-12-04: Start. Extract from <sarray.fs> and rename.
\
\ 2019-12-27: Update documentation.
