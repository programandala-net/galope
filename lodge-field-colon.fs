\ galope/lodge-field-colon.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./lodge.fs
require ./noname-field.fs

: lodge-field: ( len1 "name" -- len2 )
  noname-field create ,
  does> ( entity -- a ) ( entity dfa ) >r lodge+ r> perform ;

  \ doc{
  \
  \ lodge-field: ( n1 "name" -- n2 )
  \
  \ Create a `lodge` field _name_ with the execution semantics given
  \ below. Add one cell to offset _n1_,
  \ resulting offset _n2_.
  \
  \ ``lodge-field:`` is the lodge version of the standard ``field:``.
  \
  \ Usage example:

  \ ----
  \ 0
  \   lodge-field: my-field-0
  \   lodge-field: my-field-1
  \ constant /my-data-structure
  \ ----

  \ Execution of _name_:

  \ ----
  \ name ( n -- a )
  \ ----

  \ Convert the lodge offset _n_ (where the data structure is stored)
  \ to address _a_ of field _name_ in the `lodge`.
  \
  \ }doc


\ ==============================================================
\ Change log

\ 2017-11-12: Start. Move from _La pistola de agua_
\ (http://programandala.net/es.programa.la_pistola_de_agua.html).
\ Improve documentation.
