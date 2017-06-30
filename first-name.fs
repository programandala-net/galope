\ galope/first-name.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2015 Marcos Cruz (programandala.net)

\ History
\
\ 2015-10-16: Added to the library, taken from fsb2
\ (http://programandala.net/en.program.fsb2.html) and Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).

require ./slash-name.fs

: first-name  ( ca1 len1 -- ca2 len2 )  /name nip -  ;
  \ Get the first name from a string.
  \ A name is a substring separated by spaces.

