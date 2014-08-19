\ galope/ends-question.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-10: Copied and modified from Charscan by Wil Baden (2002-2003).
\ 2013-11-06: Changed the stack notation of flag.
\ 2014-05-29: Changed the stack notation of strings. Note about
\ 'string-suffix?'.

\ There's a similar word 'string-suffix?' (in
\ <string-suffix-question.fs>) that consumes all parameters, what
\ makes it recommended.

require ./fourth.fs

: ends? ( ca1 len1 ca2 len2 -- ca1 len1 wf )
  \ Check end of string:
  \ Is ca2 len2 the end of ca1 len1?
  \ ca1 len1 = long string
  \ ca2 len2 = end to check
  2over  dup fourth - /string  compare 0=
  ;
