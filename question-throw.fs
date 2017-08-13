\ galope/question-throw.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: ?throw ( f n -- ) swap 0<> and throw ;

  \ doc{
  \
  \ ?throw ( f n -- )
  \
  \ If _f_ is non-zero, execute `throw` with _n_ on TOS. Otherwise
  \ consume _n_ and do nothing.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-08-13: Copied from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html) and modified.
