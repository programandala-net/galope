\ galope/percent-nullify.fs
\ `%nullify`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ ==============================================================

require ./percent-to-random.fs  \ `%>random`
require ./question-nullify.fs   \ `?nullify`

: %nullify  ( x n -- x | 0 )  %>random ?nullify  ;
  \ Randomly return zero instead of _x_, _n_ percent choices.

\ ==============================================================
\ Change log

\ 2016-07-19: Write. A generalization of the old `?s`, included in the
\ deprecated module <sb.fs>.
