\ galope/package.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author:
\   Julian Fondren, 2016.
\   http://forth.minimaltype.com/packages.html
\ Adapted to Galope:
\   Marcos Cruz (programandala.net), 2017

\ ==============================================================

require ./minus-order.fs    \ `-order`
require ./plus-order.fs     \ `+order`
require ./wordlist-colon.fs \ `wordlist:`

: package ( "name" -- parent package )
  get-current >in @ bl word find
  if   nip execute
  else drop >in !  wordlist:
  then dup set-current  dup +order ;

: end-package ( parent package -- )
  -order set-current ;

: public  ( parent package -- parent package )
  over set-current ;

: private ( parent package -- parent package )
  dup  set-current ;

\ ==============================================================
\ Change log

\ 2017-08-16: Start.
