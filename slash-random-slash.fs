\ galope/slash-random-slash.fs
\ random range

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-08-16 Written.

require random.fs  \ Gforth's

: /random/  ( min max -- n )
  over >r swap - 1+ random r> +
  ;
