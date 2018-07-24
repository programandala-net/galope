\ galope/question-nullify.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017, 2018.

\ ==============================================================

require random.fs \ Gforth's `random`

: ?nullify ( x n -- x | 0 ) random 0= abs * ;

  \ doc{
  \
  \ ?nullify ( x n -- x | 0 )
  \
  \ Randomly return zero instead of _x_, one choice out of _n_.
  \
  \ See: `%nullify`, `50%nullify`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-19: Write. A generalization of the old `s?`, included in the
\ deprecated module <sb.fs>.
\
\ 2017-11-04: Improve documentation.
\
\ 2018-07-24: Improve documentation.
