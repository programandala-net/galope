\ galope/fifty-percent-nullify.fs
\ `50%-nullify`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ ==============================================================

require random.fs  \ Gforth's `random`

: 50%nullify ( x -- x | 0 )  2 random *  ;
  \ Randomly return zero instead of _x_, 50% choices.
  \ Faster and smaller than `50 %nullify`.

\ ==============================================================
\ Change log

\ 2016-07-19: Move `s?` from the deprecated module <sb.fs> and rename
\ it. More general versions have been written as `?nullify` and
\ `%nullify` in their own modules.

