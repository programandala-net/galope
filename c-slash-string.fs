\ galope/c-slash-string.fs
\ c/string

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: c/string  ( ca len c -- ca' len' ) >r 2dup r> scan nip - ;
  \ Return the left part of the given string, before the first
  \ apperance of the given character; if the character is not found,
  \ the whole string is returned.

\ ==============================================================
\ Change log

\ 2013-11-11 Written.
\
\ 2017-08-17: Update change log layout and source style.
