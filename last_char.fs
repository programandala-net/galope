\ galope/last_char.fs
\ 'last_char'

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-12-18 Added. Code copied from an application of the
\ author.

require tick-last_char.fs  \ "'last_char"

: last_char  ( a u -- c )
  \ Return the last char of an ASCII string.
  'last_char c@ 
  ;
