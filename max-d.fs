\ galope/max-d.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

s" MAX-D" environment? 0=
[if]   .( MAX-D environmental query not implemented) abort
[then] constant max-d

  \ doc{
  \
  \ max-d ( -- d )
  \
  \ _d_ is the largest usable signed double integer.
  \
  \ See: `max-ud`, `max-u`, `max-n`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-09: Start.
