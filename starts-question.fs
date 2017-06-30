\ galope/starts-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-10 Added.
\ 2013-11-06 Changed the stack notation of flag.

\ Taken and modified from Charscan by Wil Baden (2002-2003).

require ./third.fs

: starts? ( a1 u1 a2 u2 -- a1 u1 wf )
  \ Check start of string:
  \ Is a2 u2 the start of a1 u1?
  \ a1 u1 = long string
  \ a2 u2 = start to check
  2over  third min  compare 0=
  ;
