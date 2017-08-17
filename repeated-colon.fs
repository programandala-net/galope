\ galope/repeated-colon.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ Taken from:
\ http://c2.com/cgi/wiki?ForthReadability
\ Author: Samuel Falvo

\ ==============================================================

require ./module.fs

module: galope-repeated-colon-module

: invoke  ( a -- )  >r  ;

\ The Gforth's primitive 'call' could be used instead of
\ 'invoke', but it seems it's buggy in 64-bit CPUs.

export

: repeated:  ( +n -- )
  begin   dup
  while   r@ invoke 1-
  repeat  drop rdrop
  ;

\ Usage example:
\ : stars  ( +n -- )  repeated: [char] * emit  ;

;module

\ ==============================================================
\ Change log

\ 2012-06-07: Added.
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout. Update header.
