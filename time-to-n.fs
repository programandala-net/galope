\ galope/time-to-n.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

: time>n ( +n1 +n2 +n3 -- n ) 10000 * swap 100 * + + ;

  \ doc{
  \
  \ time>n ( +n1 +n2 +n3 -- n )
  \
  \ Convert second _+n1_, minute _+n2_ and hour _+n3_, or day
  \ _+n1_, month _+n2_ and year _+n3_, to _n_.
  \
  \ The conversion treats _+n3_ as ten thousands, _+n2_ as of
  \ hundreds, and _+n3_ as units.
  \
  \ See: `time>d`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-13: Extract from `time>d`. Document.
