\ galope/fetch-plus-plus.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Wil Baden, from Common Use compilation, 2003

\ ==============================================================

: @++ ( a1 -- a2 x ) dup cell+ swap @ ;

  \ doc{
  \
  \ @++ ( a1 -- a2 x )
  \
  \ Return the single-cell value _x_ stored at _a1_ and increase _a1_
  \ to point to the next cell, resulting _a2_.
  \
  \ See: `!++`, `c@++`.
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
