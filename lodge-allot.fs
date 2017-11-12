\ galope/lodge-allot.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge-allocate.fs

: lodge-allot ( n -- ) lodge-allocate throw drop ;

  \ doc{
  \
  \ lodge-allot ( n -- )
  \
  \ Add _n_ address units to the `lodge`.
  \
  \ See: `lodge-here`, `lodge-allocate`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>. Improve documentation.
