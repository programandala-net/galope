\ galope/minus-suffix.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ ==============================================================

require ./string-suffix-question.fs

: -suffix ( ca1 len1 ca2 len2 -- ca1 len1 | ca3 len3 )
  dup >r 2over 2swap string-suffix?
  if r> - else rdrop then ;
  \ Remove a suffix from a string.
  \ ca1 len1 = string
  \ ca2 len2 = suffix to be removed
  \ ca3 len3 = string without the suffix

\ ==============================================================
\ Change log

\ 2013-05-18: Added.
\
\ 2015-08-07: Updated the stack notation.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
