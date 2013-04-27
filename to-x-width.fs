\ galope/to-x-width.fs
\ '>x-width'

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-09-21 Copied from a program of the author.

: >x-width  ( a1 u1 -- a1 u2 )
  \ Convert the byte length of an UTF-8 string
  \ to the character length.
  2dup x-width nip
  ;
