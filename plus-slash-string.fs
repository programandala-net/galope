\ galope/plus-slash-string.fs
\ +/string

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)

: +/string  ( ca1 len1 -- ca2 len2 )
  \ Step forward by one char in a buffer.
  \ Inspired by Gforth's '+x/string'.
  \ ca1 len1 = buffer or string
  \ ca2 len2 = remaining buffer or string 
  char- swap char+ swap
  ;
