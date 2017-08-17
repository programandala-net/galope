\ galope/home-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./xy.fs

: home? ( -- f ) xy + 0= ;

  \ doc{
  \
  \ home? ( -- f )
  \
  \ Is the cursor at the home position (column 0, rom 0)?
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-08-17: Start. Adapted from `not-at-home?`, which was part of
\ the <l-type.fs> module.
