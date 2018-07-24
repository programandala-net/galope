\ galope/percent-to-random.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2018.

\ ==============================================================

: %>random  ( n1 -- n2 )  100 swap /  ;

  \ doc{
  \
  \ %>random  ( n1 -- n2 )
  \
  \ Convert percent _n1_ to the equivalent parameter for Gforth's
  \ ``random`` _n2_.
  \
  \ See: `%nullify`, `%50nullify`, `?nullify`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-19: Write. A factor of the generalization of the old `s?`,
\ included in the deprecated module <sb.fs>. Used by `%nullify`.
\
\ 2018-07-24: Improve documentation.
