\ galope/lodge-two-variable.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge-allot.fs
require ./lodge-create.fs

: lodge-2variable ( "name" -- )
  lodge-create [ 2 cells ] literal lodge-allot ;

  \ doc{
  \
  \ lodge-2variable ( "name" -- )
  \
  \ Create a definition for _name_. When _name_ is executed, it
  \ will return the next free address of the `lodge` when
  \ _name_ was created, where a 2-cell data space was
  \ allocated.
  \
  \ See: `lodge-variable`, `lodge-2value`, `lodge-create`,
  \ `lodge-allot`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>.
