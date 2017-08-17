\ galope/less-hex.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2015.

\ 2015-02-14: Copied from Albert van der Host's lina Forth:
\ http://home.hccnet.nl/a.w.m.van.der.horst/

: <hex  ( -- n )
  base @ hex  ;
: hex>  ( n -- )
  base !  ;

