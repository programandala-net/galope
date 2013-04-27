\ galope/question-keep.fs
\ Keep a string depending on a flag

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-06 Refactored from an application of the author.
\ 2012-05-07 Refactored from 'question-empty.fs'.

require paren-question-keep.fs  \ '(?keep)'

: ?keep  ( a u f -- a u | a 0 )
  \ Keep a string if a flag is not zero.
  \ otherwise empty it.
  0<> (?keep)
  ;
