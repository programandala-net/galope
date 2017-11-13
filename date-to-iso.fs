\ galope/date-to-iso.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./iso-8601.fs
require ./time-to-d.fs

: date>iso  ( +n1 +n2 n3 -- ca len )
  time>d <# # # iso-8601-hyphen # # iso-8601-hyphen # # # # #> ;

  \ doc{
  \
  \ date>iso  ( +n1 +n2 n3 -- ca len )
  \
  \ Convert day _+n1_, month _+n2_ and year _n3_ into ISO date _ca
  \ len_.
  \
  \ The format can be configured by `extended-iso-8601`.
  \
  \ See: `time>iso`, `time&date>iso`, `time>d`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-13: Extract from <time-and-date-to-iso.fs>, fix (add
\ leading zeroes) improve (make configurable) and document.
