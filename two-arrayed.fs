\ galope/two-arrayed.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017, 2018.

\ ==============================================================

require ./two-array-to.fs

: 2arrayed ( a "name" -- )
  create ,
  does> ( n -- ca len ) ( n dfa ) @ 2array> ;

  \ doc{
  \
  \ 2arrayed ( a "name" -- )
  \
  \ Create a 1-dimension double-cell array _name_ at _a_
  \ and the execution semantics defined below.
  \
  \ _name_ execution:
  \
  \ ----
  \ name ( n1 -- a1 )
  \ ----
  \
  \ Return address _a1_ of element _n1_.

  \ Usage example with double numbers:
  \
  \ ----

  \ here
  \   1000. 2, 2000. 2, 3000. 2, 4000. 2, 5000. 2,
  \ 2arrayed double
  \
  \ 0 double d.
  \ 3 double d.

  \ ----
  \
  \ Usage example with strings:
  \
  \ ----

  \ \ This example is Gforth-specific, because Gforth preserves
  \ \ all parsed strings in the heap, so their addresses are unique.
  \
  \ here s" nul" 2,
  \      s" unu" 2, s" du" 2, s" tri" 2, s" kvar" 2, s" kvin" 2,
  \      s" ses" 2, s" sep" 2, s" ok" 2, s" naŭ" 2, s" dek" 2,
  \
  \ 2arrayed esperanto-number
  \
  \ 0 esperanto-number 2@ type
  \ 5 esperanto-number 2@ type

  \ ----
  \
  \ See: `2array`, `2array>`. `strings:`, `array`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-08-16: Start.
\
\ 2017-10-24: Update documentation markup.
\
\ 2017-11-05: Improve documentation.
\
\ 2018-05-01: Improve documentation.
\
\ 2018-05-01: Use `2array>`.
