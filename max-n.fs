\ galope/max-n.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

s" MAX-N" environment? 0=
[if]   .( MAX-N environmental query not implemented) abort
[then] constant max-n

  \ doc{
  \
  \ max-n ( -- n )
  \
  \ _n_ is the largest usable signed integer.
  \
  \ See: `?1+!`, `max-u`, `max-d`, `max-ud`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-03-09 Added.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-11-09: Improve documentation.
