\ galope/char-to-string.fs

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


0 [if]  \ old
require ./buffer-colon.fs
2 chars buffer: (c>str)
: c>str  ( c -- ca len )
  \ Convert an ASCII char to a string.
  (c>str) c! (c>str) 1
  ;
[then]

: c>str  ( c -- ca len )
  \ Convert an ASCII char to a string.
  1 allocate throw  tuck c! 1
  ;

' c>str alias c>s  \ deprecated name
