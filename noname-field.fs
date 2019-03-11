\ galope/noname-field.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017, 2019.

\ ==============================================================

: noname-field ( -- xt ) noname field: latestxt ;

  \ doc{
  \
  \ noname-field ( n1 -- n2 xt )
  \
  \ Create an unnamed field, as created by ``field:``, and return its
  \ _xt_.
  \
  \ ``noname-field`` is a factor of `lodge-field:`.
  \
  \ See `noname-variable`, `noname-constant`, `noname-create`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-08-24: Start. Move from _La pistola de agua_
\ (http://programandala.net/es.programa.la_pistola_de_agua.fs).
\
\ 2017-11-12: Improve documentation.
\
\ 2019-03-11: Update documentation.
