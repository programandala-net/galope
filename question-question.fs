\ galope/question-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ '??' was presented at FORML 1986 by Neil Bawd.

require ./bracket-gforth-question.fs  \ '[gforth?]'

: ??  \ Compilation: ( "name" -- )
      \ Run-time: ( run-time: f -- )
  postpone if parse-name evaluate postpone then ; immediate

  \ doc{
  \
  \ ?? ( "name" -- )
  \
  \ Parse _name_. If _f_ is non-zero, evaluate _name_.
  \ Otherwise do nothing.
  \
  \ See: `[??]`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-06: Added.
\
\ 2012-05-08: Gforth-specific alternative compilation.
\
\ 2012-05-18: Added the runtime stack comment.
\
\ 2015-10-16: Version with `postpone`.
\
\ 2017-08-14: Simplified: No Gforth check; use `parse-name`. Document.
