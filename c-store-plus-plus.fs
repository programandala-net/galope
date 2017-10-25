\ galope/c-store-plus-plus.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Wil Baden, from Common Use compilation, 2003

\ ==============================================================

: c!++ ( ca1 c -- ca1 ) over c! char+ ;

  \ doc{
  \
  \ c!++ ( ca1 c -- ca2 )
  \
  \ Store _c_ at _ca1_ and increase _ca1_
  \ to point to the next character, resulting _ca2_.
  \
  \ See: `c@++`, `!++`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-18 Added.
\
\ 2012-09-14 Code reformated.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-10-25: Improve documentation.
