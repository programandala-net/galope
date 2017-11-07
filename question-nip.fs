\ galope/question-nip.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: ?nip ( x f -- f | x f ) dup if nip then ;

  \ doc{
  \
  \ ?nip ( x f -- f | x f )
  \
  \ If _f_ is zero, do nothing.  Otherwise drop _x_.
  \
  \ See: `ifelse`, `?keep`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-12-31 Added.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-11-04: Fix stack comment. Improve documentation.
\
\ 2017-11-07: Improve documentation.
