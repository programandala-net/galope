\ galope/first-name.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2015, 2017.

\ ==============================================================

require ./slash-name.fs

: first-name ( ca1 len1 -- ca2 len2 ) /name nip - ;

  \ doc{
  \
  \ first-name ( ca1 len1 -- ca2 len2 )
  \
  \ Get the first name _ca2 len2_ from the string _ca1 len1_.  A name
  \ is a substring separated by spaces.
  \
  \ See: `/name`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ History
\
\ 2015-10-16: Added to the library, taken from fsb2
\ (http://programandala.net/en.program.fsb2.html) and Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
\
\ 2017-07-15: Update layout. Improve documentation.
