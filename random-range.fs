\ galope/random-range.fs
\ Random number in a range.

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History

\ 2014-05-22: Written.

require random.fs

: random-range ( min max -- n )

  \ Return a random number from min to max.

  over - 1+ random +
  ;

