\ galope/two-if-else.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

: 2ifelse ( xd1 xd2 f -- xd1 | xd2 ) if 2nip else 2drop then ;

  \ doc{
  \
  \ 2ifelse ( xd1 xd2 f -- xd1 | xd2 )
  \
  \ If _f_ is non-zero, return double-cell item _xd2_; otherwise
  \ return double-cell item _xd1_.
  \
  \ See: `ifelse`, `?keep`, `?empty`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-07: Start. Move from _La pistola de agua_
\ (http://programandala.net/es.programa.la_pistola_de_agua.fs).
