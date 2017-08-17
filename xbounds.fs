\ galope/xbounds.fs
\ 'xbounds'

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ 2012-09-21 Copied from a program of the author.

require ./to-x-width.fs

: xbounds  ( a u -- a u' 0 )
  \ Convert a UTF-8 string to the parameters needed
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
