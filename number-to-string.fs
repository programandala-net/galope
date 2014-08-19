\ galope/number-to-string.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-11-26 First version.
\ 2014-01-29 Fix: "./" path for 'require'.

require ./double-to-string.fs

: n>str  ( n -- ca len )
  s>d d>str
  ;
