\ galope/assert.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-07-05 Added.

\ Taken from Brad Nelson's Literate Forth
\ http://bradn123.github.io/literateforth/out/literate_0012.html

: assert  ( n -- )
  0= if  abort  then
  ;
