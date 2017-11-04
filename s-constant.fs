\ galope/s-constant.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

: sconstant (  ca len "name" -- )
  create s,
  does> ( -- ca len ) ( dfa ) count ;

\ ==============================================================
\ Change log

\ 2012-05-01: Extracted from and application of the author.
\
\ 2014-11-02: Change: Stack comments.
\
\ 2017-08-17: Update change log layout. Update source style and stack
\ notation.
\
\ 2017-11-04: Rename module after the general convention, ie.
\ <s-constant.fs>.