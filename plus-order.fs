\ galope/plus-order.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author:
\   Julian Fondren, 2016.
\   http://forth.minimaltype.com/packages.html
\ Adapted to Galope:
\   Marcos Cruz (programandala.net), 2017

\ ==============================================================

require ./minus-order.fs \ `-order`

: +order ( wid -- )  dup -order >order ;

\ ==============================================================
\ Change log

\ 2017-08-16: Start.
