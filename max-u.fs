\ galope/max-u.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

s" MAX-U" environment? 0=
[if]   .( MAX-U environmental query not implemented) abort
[then] constant max-u

  \ doc{
  \
  \ max-u ( -- u )
  \
  \ _u_ is the largest usable unsigned integer.
  \
  \ See: `max-n`, `max-d`, `max-ud`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-09: Start.
