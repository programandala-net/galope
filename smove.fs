\ galope/smove.fs
\ `smove`
\ String move.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ ==============================================================

: smove  ( ca1 len1 ca2 -- )  swap chars move  ;
  \ Copy string _ca1 len1_ to _ca2_.

\ ==============================================================
\ Change log

\ 2016-07-19: Extract from the <sb.fs> module.
