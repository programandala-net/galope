\ galope/choose-curly-bracket.fs
\ `choose{`
\ Random selection for a compiled set of double cells.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2011, 2012, 2013, 2014,
\ 2016, 2017.

\ Description: Tools to compile several strings and return one of them
\ by chance at run-time.

\ ==============================================================

require random.fs  \ Gforth's `random`

require ./choose-stack.fs
require ./choose.fs

\ ==============================================================
\ Operators

: choose{ ( -- ) depth >choose-stack ;

  \ doc{
  \
  \
  \ choose{ ( -- )
  \
  \ Start a set of single-cell numbers to choose from.
  \
  \ Usage example:
  \ ----

  \ choose{ my-variable @ 1 8 16 }choose .

  \ ----
  \
  \ See: `}choose`, `2choose{`.
  \
  \ }doc

: }choose ( x1 .. xn -- x' )  depth <choose-stack - choose  ;

  \ doc{
  \
  \ }choose ( x1 .. xn -- x' )
  \
  \ Chose a random _x'_ from the set _x1 .. xn_
  \ stacked since the last unresolved `choose{`.
  \
  \ See: `}2choose`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-22: Copy, modify and rename `s{ }s` from the old module
\ <random_strings.fs>
\
\ 2017-10-26: Improve documentation.
