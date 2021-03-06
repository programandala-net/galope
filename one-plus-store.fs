\ galope/one-plus-store.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017, 2020.

\ ==============================================================

: 1+! ( a -- ) 1 swap +! ;

  \ doc{
  \
  \ 1+! ( a -- )
  \
  \ Increment the single-cell number at _a_.
  \
  \ See: `?1+!`, `1-!`, `2+!`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-05: First version.
\
\ 2012-05-07: File renamed.
\
\ 2012-09-14: Code reformated.
\
\ 2016-01-16: Updated header and layout.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-10-25: Improve documentation.
\
\ 2017-11-09: Rename `++` `1+!`. Deprecate `++` and make it a synonym
\ of `1+!`, in its own module. Improve documentation.
\
\ 2020-12-06: Update documentation with `2+!`.
