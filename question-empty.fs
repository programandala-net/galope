\ galope/question-empty.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

: ?empty ( can len f -- ca len | ca 0 ) 0= and ;

  \ doc{
  \
  \ ?empty ( can len f -- ca len | ca 0 )
  \
  \ If _f_ is non-zero, empty the string _ca len_, returning _ca 0_.
  \ Otherwise, return _ca len_.
  \
  \ See: `?keep`, `2ifelse`.
  \
  \ }doc


\ ==============================================================
\ Change log

\ 2012-05-06 Refactored from an application by the author.
\
\ 2012-05-07 Refactored. Only '?empty' remains in this file.
\
\ 2017-08-14: Simplify, don't use `(?empty)`. Document. Update source
\ layout.
\
\ 2017-11-07: Improve documentation.
