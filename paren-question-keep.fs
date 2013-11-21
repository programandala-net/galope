\ galope/paren-question-keep.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-06 Factorized from an application of the author.
\ 2012-05-07 Factorized from 'question-empty.fs'.
\ 2013-11-06 Changed the stack notation of flag.

: (?keep)  ( a u wf -- a u | a 0 )
  \ Keep a string if a flag is 'true';
  \ if the flag is 'false', empty the string.
  abs *
  ;

