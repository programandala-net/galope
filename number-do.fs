\ galope/number-do.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: #do ( n|u -- ) s" 0 ?do" evaluate ; immediate

  \ '#do' is common use.
  \ XXX TODO -- Rewrite without `evaluate`.

\ ==============================================================
\ Change log

\ 2012-05-19 Added.
\
\ 2012-09-14 Code reformated.
\
\ 2017-08-17: Update change log layout. Update header.

