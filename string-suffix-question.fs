\ galope/string-suffix-question.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-10 Added.
\ 2013-05-18 Fixed: typo. 

\ This word was inspired by Gforth's 'string-prefix?'. It's a
\ modified version of Wil Baden's 'ends?' (from Charscan,
\ 2002-2003).

require ./fourth.fs

: string-suffix? ( a1 u1 a2 u2 -- ff )
  \ Check end of string:
  \ Is a2 u2 the end of a1 u1?
  \ a1 u1 = long string
  \ a2 u2 = end to check
  2swap dup fourth - /string  compare 0=
  ;

