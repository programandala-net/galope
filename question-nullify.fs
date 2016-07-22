\ galope/question-nullify.fs
\ `?nullify`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ ==============================================================

require random.fs  \ Gforth's `random`

: ?nullify  ( x n -- x | 0 )  random 0= abs *  ;
  \ Randomly return zero instead of _x_, one choice out of _n_.

\ ==============================================================
\ History

\ 2016-07-19: Write. A generalization of the old `s?`, included in the
\ deprecated module <sb.fs>.
