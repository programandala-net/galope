\ galope/tick-last-xchar.fs
\ "'last-xchar"

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-12-18: Added. Code copied from an application of the
\ author.
\ 2013-07-07: Fix: 'do' changed to '?do'; it failed with
\   one-character strings.
\ 2015-10-13: Renamed.

require ./xbounds.fs

: 'last-xchar  ( a u -- a' )
  \ Return the address of the last xchar of a UTF-8 string.
  xbounds swap 1- swap ?do  xchar+  loop
  ;

