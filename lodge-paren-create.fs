\ galope/lodge-paren-create.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge-here.fs

: lodge-(create) ( "name" -- ) create lodge-here , ;

  \ doc{
  \
  \ lodge-(create) ( "name" -- )
  \
  \ Create a definition for _name_. When _name_ is executed, it
  \ will return the offset _+n_ of the next free available
  \ address of the `lodge` when _name_ was created.
  \
  \ ``lodge-(create)`` is a factor of `lodge-create` used by
  \ `lodge-value` and `lodge-2value`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>. Improve documentation.
