\ galope/two-choose-curly-bracket.fs
\ `2choose{`
\ Random selection for a compiled set of double cells.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2011, 2012, 2013, 2014,
\ 2016.

\ Description: Tools to compile several strings and return one of them
\ by chance at run-time.

\ ==============================================================

require random.fs  \ Gforth's `random`

require ./choose-stack.fs
require ./two-choose.fs

: 2choose{ ( -- )
  depth >choose-stack  ;
  \ Start a set of double numbers (or strings) to choose from.

: }2choose ( d1 ... dn -- d' )
  depth <choose-stack - 2 / 2choose  ;
  \ Chose a random _d'_ from the set _d1 ... dn_
  \ stacked since the last unresolved `2choose{`.

\ ==============================================================
\ Change log

\ 2016-07-22: Copy, improve and rename `s{ }s` from the old module
\ <random_strings.fs> 
