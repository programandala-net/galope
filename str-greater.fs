\ galope/str-greater.fs
\ str>

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: str> ( ca1 len1 ca2 len2 -- f ) compare 0> ;
  \ Is the ca1 len1 lexicographically larger than ca2 len2?

\ ==============================================================
\ Change log

\ 2014-03-12: Added.
\
\ 2017-08-17: Update change log layout. Update header.  Update stack
\ notation. Update source style.
