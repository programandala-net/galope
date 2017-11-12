\ galope/lodge-value.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge.fs
require ./lodge-allot.fs
require ./lodge-here.fs
require ./lodge-paren-create.fs

: lodge-value ( x "name" -- )
  lodge-here lodge-(create)
  cell lodge-allot lodge+ !
  does> ( -- x ) ( dfa ) body>lodge @ ;

  \ doc{
  \
  \ lodge-value ( x "name" -- )
  \
  \ Create a definition for _name_. When _name_ is executed, it
  \ will return _x_, which was stored in the `lodge`.
  \
  \ See: `lodge-2value`, `lodge-variable`, `lodge-(create)`,
  \ `lodge-allot`.
  \
  \ }doc

: <lodge-to> ( x "name" -- ) ' >lodge ! ;

  \ doc{
  \
  \ <lodge-to> ( x1 x2 "name" -- )
  \
  \ Store the _x_ into a `lodge-value` _name_.
  \ ``<lodge-to>`` executes the interpretation semantics of
  \ `lodge-to`.
  \
  \ See: `[lodge-to]`, `<lodge-2to>`.
  \
  \ }doc

: [lodge-to] \ Compilation: ( x "name" -- )
  ' postpone literal postpone >lodge postpone ! ; immediate

  \ doc{
  \
  \ [lodge-to] \ Compilation: ( x "name" -- )
  \
  \ Compile the words needed to store _x_ into
  \ a `lodge-value` _name_. ``[lodge-to]`` is an immediate
  \ word that executes the compilation semantics of `lodge-to`.
  \
  \ See: `<lodge-to>`, `[lodge-2to]`.
  \
  \ }doc

' <lodge-to>
' [lodge-to]
interpret/compile: lodge-to \ Interpretation: ( x "name" -- )
                            \ Compilation: ( x "name" -- )

  \ doc{
  \
  \ lodge-to \ Interpretation: ( x "name" -- )
  \          \ Compilation: ( x "name" -- )
  \
  \ Store _x_ into a `lodge-value` _name_.
  \
  \ See: `lodge-2to`, `<lodge-to>`, `[lodge-to]`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>. Improve documentation.
