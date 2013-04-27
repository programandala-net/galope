\ galope/question-question-bracket.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-08 Draft.

\ '??[' was inspired by '??' (by Neil Bawd, 1986).

: ??[  ( "text<close-bracket>" -- )
  s" if" evaluate
  [char] ] parse evaluate
  s" then" evaluate
  ;  immediate

