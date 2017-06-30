\ galope/under-plus.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-18 Added.
\ 2012-09-14 Code reformated.

\ Common use.
\ Taken from Common Use compilation 2003 by Wil Baden.

: under+  ( x1 x2 x3 -- x1+x3 x2 )
  rot + swap
  ;

