\ n-comma.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ By Marcos Cruz (programandala.net), 2019.

\ ==============================================================

: n, ( x#1 .. x#n n -- ) 0 ?do , loop ;

  \ doc{
  \
  \ n2, ( x#1 .. x#n n -- )
  \
  \ Execute ``,`` _n_ times.
  \
  \ See: `n2,`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2019-12-27: Start. Extract from "Spock!"
\ (http://programandala.net/en.program.spock.html).
