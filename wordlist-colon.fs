\ galope/wordlist-colon.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author:
\   Julian Fondren, 2016.
\   http://forth.minimaltype.com/packages.html
\ Adapted to Galope:
\   Marcos Cruz (programandala.net), 2017

\ ==============================================================

: wordlist: ( "name" -- wid )
  >in @ vocabulary dup >in ! also ' execute
  get-order swap >r 1- set-order r>
  swap >in ! dup constant ;

\ ==============================================================
\ Change log

\ 2017-08-16: Start.
