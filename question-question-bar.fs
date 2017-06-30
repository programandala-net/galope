\ galope/question-question-bar.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-08 First version.

\ '??|' was inspired by '??' (by Neil Bawd, 1986).

: ??|  ( "text<bar>" -- )
  s" if" evaluate
  [char] | parse evaluate
  s" then" evaluate
  ;  immediate

