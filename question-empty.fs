\ galope/question-empty.fs
\ Empty a string depending on a flag

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-06 Refactored from an application by the author.
\ 2012-05-07 Refactored. Only '?empty' remains in this file.

require paren-question-keep.fs  \ '(?keep)'

: ?empty  ( a u f -- a u | a 0 )
  \ Empty a string if a flag is not zero;
  \ otherwise keep it.
  0= (?keep)
  ;
