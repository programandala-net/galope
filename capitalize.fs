\ galope/capitalize.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

: capitalize ( ca len -- )
  if dup c@ toupper swap c! else drop then ;

  \ doc{
  \
  \ capitalize ( ca len -- )
  \
  \ Convert the first character of ASCII character string _ca len_ to
  \ uppercase.
  \
  \ See: `capitalized`, `xcapitalize`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-07: Start. Move from _La pistola de agua_
\ (http://programandala.net/es.programa.la_pistola_de_agua.fs).
