\ galope/slash-sentences.fs
\ `/sentences`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ ==============================================================

require ./slash-sides.fs  \ '/sides'

: /sentences  ( ca len -- ca#1 len#1 ... ca#n len#n n )
  depth >r
  begin  s" . " /sides 0=  until  2drop
  depth r> 2 - - 2/  ;
  \ Split a string _ca len_ into sentences (which were separated by a
  \ period and a space) _ca#1 len#1 ... ca#n len#n_, returning the
  \ number of resulting strings _n_.

\ ==============================================================
\ Change log

\ 2016-07-29: Write, after the code of `/csv`.
