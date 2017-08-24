\ galope/noname-constant.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: noname-constant  ( x -- xt ) noname constant latestxt ;

  \ doc{
  \
  \ noname-constant ( x -- xt )
  \
  \ Create an unnamed constant with value _x_ and return its _xt_.
  \
  \ See: `noname-2constant`, `noname-variable`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-12-01 Added.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-08-24: Remove the initial colon from the name. Document.
