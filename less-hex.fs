\ galope/less-hex.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: <hex ( -- n ) base @ hex ;

: hex> ( n -- ) base ! ;

\ ==============================================================
\ Change log

\ 2015-02-14: Copied from Albert van der Host's lina Forth:
\ http://home.hccnet.nl/a.w.m.van.der.horst/.
\
\ 2017-08-17: Update change log layout and source style.
