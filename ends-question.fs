\ galope/ends-question.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-10 Added.
\ 2013-11-06 Changed the stack notation of flag.

\ Taken and modified from Charscan by Wil Baden (2002-2003).

require ./fourth.fs

: ends? ( a1 u1 a2 u2 -- a1 u1 wf )
  \ Check end of string:
  \ Is a2 u2 the end of a1 u1?
  \ a1 u1 = long string
  \ a2 u2 = end to check
  2over  dup fourth - /string  compare 0=
  ;
