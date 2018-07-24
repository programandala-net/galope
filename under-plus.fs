\ galope/under-plus.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Credit:
\ Taken from Common Use compilation 2003, written by Wil Baden.

\ ==============================================================

: under+ ( n1|u1 n2|u2 n3|u3 -- n4|u4 n2|u2 ) rot + swap ;

  \ doc{
  \
  \ under+ ( n1|u1 n2|u2 n3|u3 -- n4|u4 n2|u2 )
  \
  \ Add _n1|u1_ to _n3|u3_ giving the sum _n4|u4_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-18 Added.
\
\ 2012-09-14 Code reformated.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2018-07-24: Improve documentation.
