\ galope/char_count.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2013-12-06 First version.

: char_count  ( ca len c -- n )
  \ Count the number of occurrences of the char c in the string ca len.
  0 2swap  bounds ?do  over i c@ = abs +  loop  nip
  ;



