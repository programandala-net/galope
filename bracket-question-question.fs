\ galope/bracket-question-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2017.

\ Credits:
\
\ '[??]' was inspired by '??' by Neil Bawd (FORML 1986).

\ ==============================================================

require ./question-keep.fs  \ '?keep'

: [??] \ Interpretation: ( f "name" -- )
       \ Compilation:    ( f "name" -- )
  parse-name rot ?keep evaluate ; immediate

  \ doc{
  \
  \ [??] \ Interpretation: ( f "name" -- )
  \      \ Compilation:    ( f "name" -- )
  \
  \ Parse _name_. If _f_ is non-zero, evaluate _name_.
  \ Otherwise do nothing.
  \
  \ See: `??`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-07 Added.
\
\ 2012-05-08 Gforth-specific alternative compilation.
\
\ 2012-05-18 Added the stack comment.
\
\ 2013-09-28 Fixed: <question-empty.fs> was required instead of
\ <question-keep.fs>.
\
\ 2017-08-14: Simplified: No Gforth check; use `parse-name`.
\ Document.
\
\ 2017-11-20: Improve documentation and header.
