\ galope/question-one-plus-store.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./max-n.fs
require ./one-plus-store.fs

: ?1+! ( a -- ) dup @ max-n = if drop else 1+! then ;

  \ doc{
  \
  \ ?1+! ( a -- )
  \
  \ Increment the single-cell number at _a_ to, but not beyond, the
  \ largest usable signed integer.
  \
  \ See: `max-n`, `1+!`, `?1-!`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-09: Start.
