\ galope/time-to-iso.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017, 2018.

\ ==============================================================

require ./iso-8601.fs
require ./time-to-d.fs

: time>iso  ( n1 n2 n3 -- ca len )
  time>d <# # # iso-8601-colon # # iso-8601-colon # # #> ;

  \ doc{
  \
  \ time>iso  ( +n1 +n2 +n3 -- ca len )
  \
  \ Convert second _+n1_, minute _+n2_ and hour _+n3_ into ISO date
  \ _ca len_.
  \
  \ The format can be configured by `extended-iso-8601`.
  \
  \ See: `iso-8601-extended`, `date>iso`, `time&date>iso`, `time>d`,
  \ `iso-8601-colon`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-13: Extract from <time-and-date-to-iso.fs>, fix (add
\ leading zeroes), improve (make configurable) and document.
\
\ 2018-07-22: Improve documentation.
