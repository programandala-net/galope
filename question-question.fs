\ galope/question-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Neil Bawd, 1986-11-29 (presented at FORML 1986)

\ ==============================================================

: ?? \ Compilation: ( "name" -- )
     \ Run-time:    ( f -- )
  postpone if parse-name evaluate postpone then ; immediate
                                                  compile-only

  \ doc{
  \
  \ ?? \ Compilation: ( "name" -- )
  \    \ Run-time:    ( f -- )
  \
  \ Compilation: Parse and evaluate _name_.
  \
  \ Run-time: If _f_ is non-zero, execute _name_, which was
  \ compiled.  Otherwise do nothing.
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
\
\ 2017-11-20: Improve documentation and header. Make `??` a
\ compile-only word.
