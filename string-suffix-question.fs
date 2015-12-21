\ galope/string-suffix-question.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History

\ 2012-12-10: Word inspired by Gforth's 'string-prefix?'; it's a 
\   modified version of Wil Baden's 'ends?' (from Charscan, 2002-2003).
\ 2013-05-18: Fixed: typo. 
\ 2013-11-06: Changed the stack notation of flag.
\ 2014-03-23: Changed the stack notation of strings.
\ 2014-05-29: Updated the stack notation of strings.
\ 2015-10-14: `str=` instead of `compare 0=`.

\ The word 'ends?' (in <ends-question.fs>) does the same but doesn't
\ consume the first string. 'string-suffix?' is recommended.

require ./fourth.fs

: string-suffix? ( ca1 len1 ca2 len2 -- wf )
  \ Check end of string:
  \ Is ca2 len2 the end of ca1 len1?
  \ ca1 len1 = long string
  \ ca2 len2 = suffix to check
  2swap dup fourth - /string  str=
  ;

