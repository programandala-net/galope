\ galope/capitalized.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./capitalize.fs \ `capitalize`

: capitalized ( ca1 len -- ca2 len )
  save-mem 2dup capitalize ;

  \ doc{
  \
  \ capitalized ( ca1 len -- ca2 len )
  \
  \ Copy ASCII character string _ca1 len_ to the heap and return it as
  \ _ca2 len_ with its first character converted to uppercase.
  \
  \ See: `capitalize`, `xcapitalized`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-07: Start. Move from _La pistola de agua_
\ (http://programandala.net/es.programa.la_pistola_de_agua.fs).
