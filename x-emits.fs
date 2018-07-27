\ galope/x-emits.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

: xemits ( xc n -- ) 0 max 0 ?do dup xemit loop drop ;

  \ doc{
  \
  \ xemits ( xc n -- )
  \
  \ If _n_ is greater than zero, display the extended character _xc_
  \ _n_ times.
  \
  \ See: `emits`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-27: Start.
