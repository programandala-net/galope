\ galope/lodge-here.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge.fs

: lodge-here ( -- +n ) /lodge @ ;

  \ doc{
  \
  \ lodge-here ( -- +n )
  \
  \ Return the offset _+n_ of the next free available address
  \ of the `lodge`, which is its length contained in `/lodge`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>.
