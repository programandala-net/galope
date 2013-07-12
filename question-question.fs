\ galope/question-question.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-06 Added.
\ 2012-05-08 Gforth-specific alternative compilation.
\ 2012-05-18 Added the runtime stack comment.

\ '??' was presented at FORML 1986 by Neil Bawd.

require ./bracket-gforth-question.fs  \ '[gforth?]'

[undefined] ?? [if]
  : ??  ( "name" -- ) ( runtime: i*x f -- j*x )
    s" if" evaluate
    [gforth?]
    [if]    parse-word
    [else]  bl word count
    [then]  evaluate s" then" evaluate
    ;  immediate
[then]

