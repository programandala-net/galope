\ galope/trim.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017, 2018.

\ ==============================================================

require ./minus-leading.fs

: trim ( ca1 len1 -- ca2 len2 ) -leading -trailing ;

  \ doc{
  \
  \ trim ( ca1 len1 -- ca2 len2 ) -leading -trailing ;
  \
  \ Remove trailing and leading spaces from the character string _ca1
  \ len1_, returning the character string _ca2 len2_.
  \
  \ See: `-leading`, `nospace`, `unspace`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-10-22 Added.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2018-07-24: Improve documentation.
