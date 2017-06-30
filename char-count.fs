\ galope/char-count.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2013-12-06: First version.
\ 2015-10-13: Renamed.

: char-count  ( ca len c -- n )
  \ Count the number of occurrences of the char c in the string ca len.
  0 2swap  bounds ?do  over i c@ = abs +  loop  nip
  ;



