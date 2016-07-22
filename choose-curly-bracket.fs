\ galope/choose-curly-bracket.fs
\ `choose{`
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
require ./choose.fs

\ ==============================================================
\ Operators

: choose{ ( -- )  depth >choose-stack  ;
  \ Start a set of numbers to choose from.

: }choose ( x1 ... xn -- x' )  depth <choose-stack - choose  ;
  \ Chose a random _x'_ from the set _x1 ... xn_
  \ stacked since the last unresolved `choose{`.

\ ==============================================================
\ History

\ 2016-07-22: Copy, modify and rename `s{ }s` from the old module
\ <random_strings.fs> 
