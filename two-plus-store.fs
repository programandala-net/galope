\ galope/two-plus-store.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2020.

\ ==============================================================

: 2+! ( a -- ) 2 swap +! ;

  \ doc{
  \
  \ 2+! ( a -- )
  \
  \ Add 2 to the single-cell number at _a_.
  \
  \ See: `1+!`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2020-12-06: Start.
