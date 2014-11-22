\ galope/svariable.fs
\ String variable

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012: First version.
\ 2013-11-25: Factored out with '/counted-string'.
\ 2014-01-29: Fix: "./" path for 'require'.

require ./slash-counted-string.fs

: svariable  ( "name" -- )
  \ Create a string variable.
  create 0 c, /counted-string allot align
  ;
