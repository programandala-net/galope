\ galope/colon-noname-two-constant.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: noname-2constant ( d -- xt ) noname 2constant latestxt ;

  \ doc{
  \
  \ noname-2constant ( x1 x2 -- xt )
  \
  \ Create an unnamed double-cell constant with value _x1 x2_ and
  \ return its _xt_.
  \
  \ See: `noname-constant`, `noname-2variable`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-12-01 Added.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-08-24: Remove the initial colon from the name. Document.
