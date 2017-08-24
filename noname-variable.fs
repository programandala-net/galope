\ galope/colon-noname-variable.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: noname-variable  ( -- xt ) noname variable latestxt ;

  \ doc{
  \
  \ noname-variable ( -- xt )
  \
  \ Create an unnamed variable and return its _xt_.
  \
  \ See: `noname-2variable`, `noname-constant`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-12-01 Added.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-08-24: Remove the initial colon from the name. Document.
