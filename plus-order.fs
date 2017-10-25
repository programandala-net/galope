\ galope/plus-order.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author:
\   Julian Fondren, 2016.
\   http://forth.minimaltype.com/packages.html
\ Adapted to Galope:
\   Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./minus-order.fs \ `-order`

: +order ( wid -- ) dup -order >order ;

  \ doc{
  \
  \ +order ( wid -- )
  \
  \ Remove all _wid_ from the search order; then
  \ add _wid_ to the top of the search order.
  \
  \ See: `-order`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-08-16: Start.
\
\ 2017-08-17: Document.
\
\ 2017-10-25: Update header format.
