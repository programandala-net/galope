\ galope/x-capitalized.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./x-capitalize.fs \ `xcapitalize`

: xcapitalized ( xca1 len -- xca2 len )
  save-mem 2dup xcapitalize ;

  \ doc{
  \
  \ xcapitalized ( xca1 len -- xca2 len )
  \
  \ Copy UTF-8 character string _xca1 len_ to the heap and return it
  \ as _xca2 len_ with its first character converted to uppercase.
  \
  \ A conversion table must be defined first with `xtable[`.
  \
  \ See: `xcapitalize`, `capitalized`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-07: Start. Move from _La pistola de agua_
\ (http://programandala.net/es.programa.la_pistola_de_agua.fs).
\
\ 2017-11-08: Improve documentation.
