\ galope/contains-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Taken from Charscan by Wil Baden (2002-2003).

\ ==============================================================

: contains? ( a1 u1 a2 u2 -- a1 u1 wf )
  2over 2swap search nip nip ;
  \ Test that a string contains another string.
  \ a1 u1 = string to search
  \ a2 u2 = string to search for

\ ==============================================================
\ Change log

\ 2012-12-10 Added.
\
\ 2013-11-06 Changed the stack notation of flag.
\
\ 2017-08-17: Update change log layout. Update header.
