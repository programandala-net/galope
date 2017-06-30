\ galope/d-to-str.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-11-26: First version.
\ 2015-10-14: Fixed: sign was missing. File renamed.

[undefined] tuck [if]
  : tuck  ( x1 x2 -- x2 x1 x2 )  swap over  ;
[then]

: d>str  ( ud -- ca len )
  tuck dabs <# #s rot sign #>
  ;
