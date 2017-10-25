\ galope/bracket-true.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

[undefined] [true] [if]
  true constant [true] immediate
[then]

  \ doc{
  \
  \ [true] ( -- true )
  \
  \ Return a false flag, a single-cell value with all bits set.
  \ ``[true]`` is an immediate word.
  \
  \ See: `[false]`, `[or]`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-08 First version.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-10-25: Improve documentation.
