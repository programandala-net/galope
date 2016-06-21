\ galope/last-xchar.fs
\ 'last-xchar'

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-12-18 Added. Code copied from an application of the
\ author.
\ 2015-10-13: Renamed.

require tick-last-xchar.fs  \ "'last_xchar"

: last-xchar  ( a u -- c )
  \ Return the last xchar of a UTF8 string.
  'last-xchar xc@
  ;

