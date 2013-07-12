\ galope/minus-suffix.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-05-18 Added.

require ./string-suffix-question.fs

: -suffix ( a1 u1 a2 u2 -- a1 u1 | a3 u3 )
  \ Remove a suffix from a string.
  \ a1 u1 = string
  \ a2 u2 = suffix to be removed
  \ a3 u3 = string without the suffix
  dup >r 2over 2swap string-suffix?
  if  r> -  else  rdrop  then 
  ;

