\ galope/char-to-string.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-06-10 Added.

: c>s  ( c -- ca len )
  \ Convert an ASCII char to a string.
  pad c! pad 1
  ;
