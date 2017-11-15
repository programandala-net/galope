\ galope/warning-paren.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./question-warning.fs

: warning( ( "ccc<paren>" -- )
  ')' parse true ['] type ?warning ; immediate

  \ doc{
  \
  \ warning( ( "ccc<paren>" -- )
  \
  \ Parse _ccc_ delimited by ')' and display _ccc_ as a warning.
  \
  \ ``warning(`` is an immediate word.
  \
  \ See: `?warning`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-14: Start.
\
\ 2017-11-15: Require `?warning`, which is provided only by Gforth
\ 0.7.9.
