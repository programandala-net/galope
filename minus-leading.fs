\ galope/minus-leading.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-20 Added.
\ 2012-09-14 Code reformated.
\ 2012-09-19 Stack comment fixed.

\ '-leading' is common use.

: -leading  ( a1 u1 -- a2 u2 )
  bl skip
  ;

