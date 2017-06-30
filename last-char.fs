\ galope/last-char.fs
\ 'last-char'

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History.
\ 2012-12-18: Added. Code copied from an application of the
\ author.
\ 2015-10-13: Renamed.

require tick-last-char.fs  \ "'last_char"

: last-char  ( a u -- c )
  \ Return the last char of an ASCII string.
  'last-char c@
  ;
