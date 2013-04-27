\ galope/starts-question.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-10 Added.

\ Taken and modified from Charscan by Wil Baden (2002-2003).

require galope/third.fs

: starts? ( a1 u1 a2 u2 -- a1 u1 ff )
  \ Check start of string:
  \ Is a2 u2 the start of a1 u1?
  \ a1 u1 = long string
  \ a2 u2 = start to check
  2over  third min  compare 0=
  ;
