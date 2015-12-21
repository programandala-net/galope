\ galope/slash-name.fs

\ This file is part of Galope

\ Copyright (C) 2015 Marcos Cruz (programandala.net)

\ History
\
\ 2015-10-16: Added to the library, taken from fsb2
\ (http://programandala.net/en.program.fsb2.html) and Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).

: /name  ( ca1 len1 -- ca2 len2 ca3 len3 )
  \ Divide a string at its first name (a substring separated by
  \ spaces).
  \ ca1 len1 = Text.
  \ ca2 len2 = Same text, from the start of its first name.
  \ ca3 len3 = Same text, from the char after its first name.
  bl skip 2dup bl scan  ;

