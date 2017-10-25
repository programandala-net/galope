\ galope/store-plus-plus.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Wil Baden, from Common Use compilation, 2003

\ ==============================================================

: !++ ( a1 x -- a2 ) over ! cell+ ;

  \ doc{
  \
  \ !++ ( a1 x -- a2 )
  \
  \ Store _x_ at _a1_ and increase _a1_
  \ to point to the next cell, resulting _a2_.
  \
  \ See: `@++`, `c!++`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-18 Added.
\
\ 2017-08-17: Update change log layout. Update header and source
\ style.
\
\ 2017-10-25: Improve documentation.
