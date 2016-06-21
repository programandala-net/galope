\ galope/repeated-colon.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-06-07: Added.
\ 2014-11-17: Module name updated.

\ Taken from:
\ http://c2.com/cgi/wiki?ForthReadability
\ Author: Samuel Falvo

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
