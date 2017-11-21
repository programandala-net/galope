\ galope/question-one-plus.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

: ?1+ ( n1 f -- n1 | n2 ) 0<> abs + ;

  \ doc{
  \
  \ ?1+ ( n1 f -- n1 | n2 )
  \
  \ If _f_ is non-zero, increase _n1_ returning _n2_.
  \ Otherwise return _n1_.
  \
  \ See: `?1+!`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-21: Move `exit+` from _La pistola de agua_
\ (http://programandala.net/es.programa.la_pistola_de_agua.html) and
\ rename it `?1+`.
