\ galope/c-slash-string.fs
\ c/string

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-11-11 Written.

: c/string  ( ca len c -- ca' len' )
  \ Return the left part of the given string, before the first apperance of the
  \ given character; if the character is not found, the whole string
  \ is returned.
  >r 2dup r> scan nip -
  ;
