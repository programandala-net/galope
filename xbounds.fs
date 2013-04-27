\ galope/xbounds.fs
\ 'xbounds'

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-09-21 Copied from a program of the author.

require galope/to-x-width.fs

: xbounds  ( a u -- a u' 0 )
  \ Convert an UTF-8 string to the parameters needed
  \ to explore it in a DO LOOP structure.
  >x-width 0
  ;

0 [if]
  \ Usage example

  \ UTF-8 string loop:
  xbounds do  xc@+ xemit  loop  drop

  \ Compare it to an ASCII string loop:
  bounds do  i c@ emit  loop

[then]
