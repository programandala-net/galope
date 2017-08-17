\ galope/percent-to-random.fs
\ `%>random`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ ==============================================================

: %>random  ( n1 -- n2 )  100 swap /  ;
  \ Convert percent _n1_ to the equivalent parameter for `random`
  \ _n2_.

\ ==============================================================
\ Change log

\ 2016-07-19: Write. A factor of the generalization of the old `s?`,
\ included in the deprecated module <sb.fs>. Used by `%nullify`.
