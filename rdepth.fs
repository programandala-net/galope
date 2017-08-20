\ galope/rdepth.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

: rdepth ( -- +n ) rp0 @ rp@ - cell / ;
  \ Number of values on the return stack.

\ ==============================================================
\ Change log

\ 2014-02-20 Written.
\
\ 2017-08-17: Update change log layout and source style.
