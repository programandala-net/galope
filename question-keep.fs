\ galope/question-keep.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017.

\ ==============================================================

: ?keep ( ca len f -- ca len | ca 0 ) 0<> and ;

  \ doc{
  \
  \ ?keep ( can len f -- ca len | ca 0 )
  \
  \ If _f_ is non-zero, keep the string _ca len_.  Otherwise, empty
  \ it, returning _ca 0_.
  \
  \ See: `?empty`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-06: Refactor from an application of the author.
\
\ 2012-05-07: Refactor from 'question-empty.fs'.
\
\ 2016-07-08: Update source layout and header.
\
\ 2017-08-14: Simplify, don't use `(?empty)`. Document. Update source
\ layout and header.
