\ galope/slash-name.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2015,2017 Marcos Cruz (programandala.net)

\ History
\
\ 2015-10-16: Added to the library, taken from fsb2
\ (http://programandala.net/en.program.fsb2.html) and Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
\
\ 2017-02-14: Improve documentation.

: /name  ( ca1 len1 -- ca2 len2 ca3 len3 )
  bl skip 2dup bl scan  ;
  \ Divide a string _ca1 len1_ at its first name (a substring
  \ separated by spaces), returning substring _ca2 len2_ (from the
  \ start of the first name in _ca1 len1_) and substring _ca3 len3_
  \ (from the character after the first name in _ca1 len1_).

