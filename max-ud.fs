\ galope/max-ud.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

s" MAX-UD" environment? 0=
[if]   .( MAX-UD environmental query not implemented) abort
[then] constant max-ud

  \ doc{
  \
  \ max-ud ( -- ud )
  \
  \ _ud_ is the largest usable unsigned double integer.
  \
  \ See: `max-u`, `max-d`, `max-n`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-09: Start.
