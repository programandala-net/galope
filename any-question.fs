\ galope/any-question.fs
\ `any?`

\ This file is part of Galope

\ History
\
\ 2015-12-11: Start. Code from Solo Forth. Original code from F83.

variable (any?)

: any?  ( x0 x1..xn n -- f )
  dup 1+ roll (any?) !  0 swap 0 do  swap (any?) @ = or  loop  ;
  \ Is any _x1..xn_ equal to _x0_?

