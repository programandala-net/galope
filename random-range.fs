\ galope/random-range.fs
\ Random number in a range.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ ==============================================================

require random.fs

: random-range ( min max -- n )
  over - 1+ random + ;
  \ Return a random number from min to max.

\ ==============================================================
\ Change log

\ 2014-05-22: Written.
\
\ 2017-08-17: Update change log layout. Update source style.
