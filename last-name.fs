\ galope/last-name.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2015.

\ ==============================================================

require ./trim.fs

: last-name  ( ca1 len1 -- ca2 len2 )
  trim begin  2dup bl scan bl skip dup
       while  2nip
       repeat 2drop ;
  \ Get the last name from a string.
  \ A name is a substring separated by spaces.

\ ==============================================================
\ Change log

\ 2015-10-16: Added to the library, taken from fsb2
\ (http://programandala.net/en.program.fsb2.html) and Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
