\ galope/last_xchar.fs
\ 'last_xchar'

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-12-18 Added. Code copied from an application of the
\ author.

require tick-last_xchar.fs  \ "'last_xchar"

: last_xchar  ( a u -- c )
  \ Return the last xchar of a UTF8 string.
  'last_xchar xc@ 
  ;

