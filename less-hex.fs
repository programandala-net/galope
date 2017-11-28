\ galope/less-hex.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: <hex ( -- n ) base @ hex ;

  \ doc{
  \
  \ <hex ( -- n )
  \
  \ Start an "hexadecimal zone", which will be ended by `hex>`.  Leave
  \ the current content of ``base`` _n_ and set ``base`` to sixteen.
  \
  \ }doc

: hex> ( n -- ) base ! ;


  \ doc{
  \
  \ hex> ( n -- )
  \
  \ End an "hexadecimal zone" that was started by `hex>`, restoring
  \ the previous value of ``base`` _n_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2015-02-14: Copied from Albert van der Host's lina Forth:
\ http://home.hccnet.nl/a.w.m.van.der.horst/.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-11-28: Improve documentation.
