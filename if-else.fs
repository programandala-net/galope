\ galope/if-else.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

: ifelse ( x1 x2 f -- x1 | x2 ) if nip else drop then ;

  \ doc{
  \
  \ ifelse ( x1 x2 f -- x1 | x2 )
  \
  \ If _f_ is non-zero, return _x2_; otherwise return item _x1_.
  \
  \ See: `2ifelse`, `?nip`, `?keep`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-07: Start. Move from _La pistola de agua_
\ (http://programandala.net/es.programa.la_pistola_de_agua.fs).
