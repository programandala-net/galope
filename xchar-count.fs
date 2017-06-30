\ galope/xchar-count.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2013-12-06: First version.
\ 2015-10-13: Renamed.

require ./xbounds.fs

: xchar-count  ( xca len xc -- n )
  \ Count the number of occurrences of the char xc in the string xca len.
  0 2swap  xbounds ?do  xc@+ 3 pick = abs  rot + swap  loop  drop nip
  ;
