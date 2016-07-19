\ galope/any-question.fs
\ `any?`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: John A. Peters, 1984. Included in a tool set written for the
\ CP/M implementation of Laxen&Perry's F83 2.1.1.

\ ==============================================================

variable (any?)

: any?  ( x0 x1..xn n -- f )
  dup 1+ roll (any?) !  0 swap 0 do  swap (any?) @ = or  loop  ;
  \ Is any _x1..xn_ equal to _x0_?

\ ==============================================================
\ History

\ 2015-12-11: Copy from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html). Original code
\ from John A. Peters' tools for CP/M F83 2.1.1.
\
\ 2016-07-11: Update source layout and file header. Fix and complete
\ the credits.
