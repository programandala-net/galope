\ galope/colon-noname-variable.fs
\ :noname-variable

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-12-01 Added.

: :noname-variable  ( -- xt )
  \ Create an anonymous variable.
  noname variable latestxt
  ;

