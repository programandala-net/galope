\ galope/lodge-two-value.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge.fs
require ./lodge-allot.fs
require ./lodge-here.fs
require ./lodge-paren-create.fs

: lodge-2value ( x1 x2 "name" -- )
  lodge-here lodge-(create)
  [ 2 cells ] literal lodge-allot lodge+ 2!
  does> ( -- x1 x2 ) ( dfa ) body>lodge 2@ ;

  \ doc{
  \
  \ lodge-2value ( x1 x2 "name" -- )
  \
  \ Create a definition for _name_. When _name_ is executed, it will
  \ return _x1 x2_, which were stored in the `lodge`.
  \
  \ See: `lodge-value`, `lodge-2variable`, `lodge-(create)`,
  \ `lodge-allot`.
  \
  \ }doc

: <lodge-2to> ( x1 x2 "name" -- ) ' >lodge 2! ;

  \ doc{
  \
  \ <lodge-2to> ( x1 x2 "name" -- )
  \
  \ Store the cell pair _x1 x2_ into a `lodge-2value` _name_.
  \ ``<lodge-2to>`` executes the interpretation semantics of
  \ `lodge-2to`.
  \
  \ See: `[lodge-2to]`, `<lodge-to>`.
  \
  \ }doc

: [lodge-2to] \ Compilation: ( x1 x2 "name" -- )
  ' >lodge postpone 2literal postpone 2! ; immediate

  \ doc{
  \
  \ [lodge-2to] \ Compilation: ( x1 x2 "name" -- )
  \
  \ Compile the words needed to store the cell pair _x1 x2_ into
  \ a `lodge-2value` _name_. ``[lodge-2to]`` is an immediate
  \ word that executes the compilation semantics of `lodge-2to`.
  \
  \ See: `<lodge-2to>`, `[lodge-to]`.
  \
  \ }doc

' <lodge-2to>
' [lodge-2to]
interpret/compile: lodge-2to \ Interpretation: ( x1 x2 "name" -- )
                             \ Compilation: ( x1 x2 "name" -- )

  \ doc{
  \
  \ lodge-2to \ Interpretation: ( x1 x2 "name" -- )
  \           \ Compilation: ( x1 x2 "name" -- )
  \
  \ Store _x1 x2_ into a `lodge-2value` _name_.
  \
  \ See: `lodge-to`, `<lodge-2to>`, `[lodge-2to]`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>. Improve documentation.
