\ galope/two-choose-curly-bracket.fs
\ `2choose{`
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
require ./two-choose.fs

: 2choose{ ( -- )
  depth >choose-stack  ;

  \ doc{
  \
  \ 2choose{ ( -- )
  \
  \ Start a set of double-cell numbers to choose from.
  \
  \ Usage example:
  \ ----

  \ 2choose{ my-2variable 2@ 1. 8. 16. }2choose d.
  \ 2choose{ s" this" s" that" }2choose type

  \ ----
  \
  \ See: `}2choose`, `choose{`.
  \
  \ }doc

: }2choose ( dx1 .. dxn -- dx' )
  depth <choose-stack - 2 / 2choose  ;
  \ Chose a random _d'_ from the set _d1 ... dn_
  \ stacked since the last unresolved `2choose{`.

  \ doc{
  \
  \ }2choose ( dx1 .. dxn -- dx' )
  \
  \ Chose a random _dx'_ from the set _dx1 .. dxn_
  \ stacked since the last unresolved `2choose{`.
  \
  \ See: `}choose`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-22: Copy, improve and rename `s{ }s` from the old module
\ <random_strings.fs>
\
\ 2017-10-26: Improve documentation.
