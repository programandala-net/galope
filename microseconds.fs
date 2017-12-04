\ galope/microseconds.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

: microseconds ( u -- )
  s>d utime d+ begin 2dup utime d< until 2drop ;

  \ doc{
  \
  \ microseconds ( u -- )
  \
  \ Wait at least _u_ microseconds.
  \
  \ See: `?microseconds`, `seconds`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-12-04: Start.
