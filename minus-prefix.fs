\ galope/minus-prefix.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-05-18 Added.

require ./gforth-question.fs

gforth? 0= [if]
  : string-prefix?  ( a1 u1 a2 u2 -- f )
    tuck 2>r min 2r> str=
    ;
[then]

: -prefix  ( a1 u1 a2 u2 -- a1 u1 | a3 u3 )
  \ Remove a prefix from a string.
  \ a1 u1 = string
  \ a2 u2 = prefix to be removed
  \ a3 u3 = string without the prefix
  dup >r 2over 2swap string-prefix?
  if  swap r@ + swap r> -  else  rdrop  then 
  ;

