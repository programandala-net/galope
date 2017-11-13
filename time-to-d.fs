\ galope/time-to-d.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./time-to-n.fs

: time>d ( +n1 +n2 +n3 -- d ) time>n s>d ;

  \ doc{
  \
  \ time>d ( n1 n2 n3 -- d )
  \
  \ Convert second _+n1_, minute _+n2_ and hour _+n3_, or day
  \ _+n1_, month _+n2_ and year _+n3_, to _d_.
  \
  \ The conversion treats _+n3_ as ten thousands, _+n2_ as of
  \ hundreds, and _+n3_ as units.
  \
  \ ``time>d`` is a factor of `time>iso` and `date>iso`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-13: Extract from <time-and-date-to-iso.fs>. Factor
\ `time>n`. Improve documentation.
