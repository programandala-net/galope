\ galope/u-percent.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2015, 2016, 2017.

\ ==============================================================

: u% ( u1 u2 -- u3 ) >r 100 um* r> um/mod nip ;

  \ doc{
  \
  \ u% ( u1 u2 -- u3 )
  \
  \ _u1_ is percentage _u3_ of _u2_.
  \
  \ See: `%`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-19: Copy from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
