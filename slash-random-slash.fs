\ galope/slash-random-slash.fs
\ random range

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-08-16 Written.

require random.fs  \ Gforth's

: /random/  ( min max -- n )
  over >r swap - 1+ random r> +
  ;
