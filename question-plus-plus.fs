\ galope/question-plus-plus.fs
\ `?++`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017.

\ ==============================================================

: ?++ ( a -- ) dup @ 1+ 0>= abs swap +! ;
  \ Increment the contents of _a_, but only if it's not the largest
  \ usable signed integer.

  \ XXX OLD
  \ dup @ 1+ dup 0< if 2drop else swap ! then ;
  \ dup @ 1+ dup 0< if 2drop exit then swap ! ;

\ ==============================================================
\ Change log

\ 2016-07-11: Move from "Asalto y castigo"
\ (http://programandala.net/en.program.asalto_y_castigo.forth.html)
\ and improve.
\
\ 2017-08-17: Fix change log title. Update source style.
