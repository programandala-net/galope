\ galope/tick-last-char.fs
\ "'last-char"

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-12-18: Added. Code copied from an application of the
\ author.
\ 2015-10-13: Renamed; `chars`.

: 'last-char  ( a u -- a' )
  \ Return the address of the last char of an ASCII string.
  + [ 1 chars ] -
  ;
