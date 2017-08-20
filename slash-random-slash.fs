\ galope/slash-random-slash.fs
\ random range

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require random.fs  \ Gforth's

: /random/ ( min max -- n ) over >r swap - 1+ random r> + ;

\ ==============================================================
\ Change log

\ 2013-08-16 Written.
\
\ 2017-08-17: Update change log layout and source style.
