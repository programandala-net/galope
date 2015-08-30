\ galope/minus-suffix.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-05-18: Added.
\ 2015-08-07: Updated the stack notation.

require ./string-suffix-question.fs

: -suffix ( ca1 len1 ca2 len2 -- ca1 len1 | ca3 len3 )
  \ Remove a suffix from a string.
  \ ca1 len1 = string
  \ ca2 len2 = suffix to be removed
  \ ca3 len3 = string without the suffix
  dup >r 2over 2swap string-suffix?
  if  r> -  else  rdrop  then 
  ;

