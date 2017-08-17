\ galope/colon-noname-constant.fs
\ :noname-constant

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-12-01 Added.

: :noname-constant  ( x -- xt )
  \ Create an anonymous constant.
  noname constant latestxt
  ;
