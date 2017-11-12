\ galope/lodge-create.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge.fs
require ./lodge-paren-create.fs

: lodge-create ( "name" -- ) lodge-(create) does> body>lodge ;

  \ doc{
  \
  \ lodge-create ( "name" -- )
  \
  \ Create a definition for _name_. When _name_ is executed, it
  \ will return the next free address of the `lodge` when
  \ _name_ was created.
  \
  \ See: `lodge-here`, `body>lodge`, `lodge-(create)`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>. Improve documentation.
