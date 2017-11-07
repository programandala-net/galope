\ galope/x-capitalize.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./x-c-store.fs
require ./xcase.fs

: xcapitalize ( xca len -- )
  if dup xc@ xtoupper swap xc! else drop then ;

  \ doc{
  \
  \ xcapitalize ( xca len -- )
  \
  \ Convert the first character of UTF-8 character string _xca len_ to
  \ uppercase.
  \
  \ See: `xcapitalized`, `capitalize`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-07: Start. Move from _La pistola de agua_
\ (http://programandala.net/es.programa.la_pistola_de_agua.fs).
