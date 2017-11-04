\ galope/minus-leading.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2015, 2017.

\ ==============================================================

: -leading ( ca1 len1 -- ca2 len2 ) bl skip ;

  \ doc{
  \
  \ -leading ( ca1 len1 -- ca2 len2 )
  \
  \ Remove leading spaces from character string _ca1 len1_, resulting
  \ character string _ca2 len2_.
  \
  \ See: `-prefix`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-20 Added.
\
\ 2012-09-14 Code reformated.
\
\ 2012-09-19 Fixed the stack comment.
\
\ 2015-10-05 Changed the stack comment.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-11-04: Improve documentation.
