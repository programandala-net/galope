\ galope/tick-last_char.fs
\ "'last_char"

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-12-18 Added. Code copied from an application of the
\ author.

: 'last_char  ( a u -- a' )
  \ Return the address of the last char of an ASCII string.
  2 1-
  ;
