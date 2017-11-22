\ galope/minus-e-keys.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017

\ ==============================================================

: -ekeys ( -- ) begin ekey? while ekey drop repeat ;

  \ doc{
  \
  \ -ekeys ( -- )
  \
  \ Remove all available keyboard events.
  \
  \ See: `-keys`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-22: Start.
