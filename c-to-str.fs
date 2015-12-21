\ galope/c-to-str.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-06-10 Added.
\ 2013-11-26 Alias 'c>str'.
\ 2013-12-29 Ad hoc buffer instead of 'pad'; word and alias names
\ exchanged.
\ 2014-01-01 Fix: One single buffer made it impossible to use this
\ word several times in the same code, because every string overwrited
\ the previous one! Allocated memory is used instead, as Gforth strings do.
\ 2015-10-15: Renamed the file.


0 [if]  \ old
require ./buffer-colon.fs
2 chars buffer: (c>str)
: c>str  ( c -- ca len )
  (c>str) c! (c>str) 1  ;
  \ Convert an ASCII char to a string.
[then]

: c>str  ( c -- ca len )
  1 allocate throw  tuck c! 1  ;
  \ Convert an ASCII char to a string.

' c>str alias c>s  \ deprecated name