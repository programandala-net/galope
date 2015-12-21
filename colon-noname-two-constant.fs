\ galope/colon-noname-two-constant.fs
\ :noname-2constant

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-12-01 Added.

: :noname-2constant  ( d -- xt )
  \ Create an anonymous double constant.
  noname 2constant latestxt
  ;

