\ galope/minus-order.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author:
\   Julian Fondren, 2016.
\   http://forth.minimaltype.com/packages.html
\ Adapted to Galope:
\   Marcos Cruz (programandala.net), 2017

\ ==============================================================

: -order {: wid -- :}
  get-order n>r r> dup
  begin  dup
  while  1- r@ wid =
         if   rdrop -1 under+
         else r> -rot
         then
  repeat drop set-order ;

  \ doc{
  \
  \ -order ( wid -- )
  \
  \ Remove all _wid_ from the search order.
  \
  \ See: `+order`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-08-16: Start.
\ 2017-08-17: Document.
