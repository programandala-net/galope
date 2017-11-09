\ galope/random-range.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2017.

\ ==============================================================

require random.fs

: random-range ( n1 n2 -- n3 ) over - 1+ random + ;

  \ doc{
  \
  \ random-range ( n1 n2 -- n3 )
  \
  \ Return a random number _n_ from _n1_ (minimum) to _n2_ (maximum).
  \
  \ See: `randomize`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-08-16: Written as `/random/`.
\
\ 2014-05-22: Rewritten and improved as `random-range`.
\
\ 2017-08-17: Update change log layout. Update source style.
\
\ 2017-11-09: Improve documentation.
