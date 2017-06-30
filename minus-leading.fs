\ galope/minus-leading.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-20 Added.
\ 2012-09-14 Code reformated.
\ 2012-09-19 Fixed the stack comment.
\ 2015-10-05 Changed the stack comment.

\ '-leading' is common use.

: -leading  ( ca1 len1 -- ca2 len2 )
  bl skip
  ;

