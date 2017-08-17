\ galope/starts-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author:
\   Wil Baden
\   From Charscan (2002-2003)
\ Modified by:
\   Marcos Cruz (programandala.net), 2012.

\ ==============================================================

require ./third.fs

: starts? ( a1 u1 a2 u2 -- a1 u1 wf )
  2over third min compare 0= ;
  \ Check start of string:
  \ Is a2 u2 the start of a1 u1?
  \ a1 u1 = long string
  \ a2 u2 = start to check

\ ==============================================================
\ Change log

\ 2012-12-10 Added.
\
\ 2013-11-06 Changed the stack notation of flag.
\
\ 2017-08-17: Update change log layout. Update header and source
\ style.
