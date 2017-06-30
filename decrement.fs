\ galope/decrement.fs
\ Decrement the content of an address to, but not beyond, zero.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-07-12 Added. Code by Brad Rodriguez:
\ <http://camelforth.com/news.php?extend.44.2>.

: decrement  ( a -- )
  dup @ ?dup if  1- swap !  else  drop  then
  ;
[then]

