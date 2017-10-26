\ galope/colon-constant.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: :constant ( x ca len -- ) nextname constant ;

  \ doc{
  \
  \ Create a constant with name _ca len_ and value _x_.
  \
  \ See: `:svariable`, `:$variable`, `:alias`, `:create`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-12-01 Added.
\
\ 2017-08-20: Update change log layout. Update source style.
\
\ 2017-10-26: Improve documentation.
