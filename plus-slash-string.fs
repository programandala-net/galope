\ galope/plus-slash-string.fs
\ +/string

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: +/string ( ca1 len1 -- ca2 len2 )
  char- swap char+ swap ;
  \ Step forward by one char in a buffer.
  \ Inspired by Gforth's '+x/string'.
  \ ca1 len1 = buffer or string
  \ ca2 len2 = remaining buffer or string

\ ==============================================================
\ Change log

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)
\
\ 2017-08-17: Update change log layout and source style.
