\ galope/bracket-question-question.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-07 Added.
\ 2012-05-08 Gforth-specific alternative compilation.
\ 2012-05-18 Added the stack comment.

\ '[??]' was inspired by '??' by Neil Bawd (FORML 1986).

require ./bracket-gforth-question.fs  \ '[gforth?]'
require ./question-empty.fs  \ '?keep'

: [??]  ( f "name" -- )
  [gforth?]
  [if]    parse-word
  [else]  bl word count
  [then]  rot ?keep evaluate
  ; immediate

