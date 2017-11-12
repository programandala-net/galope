\ galope/lodge-variable.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge-allot.fs
require ./lodge-create.fs

: lodge-variable ( "name" -- ) lodge-create cell lodge-allot ;

  \ doc{
  \
  \ lodge-variable ( "name" -- )
  \
  \ Create a definition for _name_. When _name_ is executed, it
  \ will return the next free address of the `lodge` when
  \ _name_ was created, where a 1-cell data space was
  \ allocated.
  \
  \ See: `lodge-2variable`, `lodge-value`, `lodge-create`,
  \ `lodge-allot`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>.
