\ galope/store-plus-plus.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-18 Added.

\ Taken from Common Use compilation 2003 by Wil Baden.

: !++  ( a x -- a' )
  over ! cell+
  ;


