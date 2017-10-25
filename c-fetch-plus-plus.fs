\ galope/c-fetch-plus-plus.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Wil Baden, from Common Use compilation, 2003

\ ==============================================================

: c@++ ( ca1 -- ca2 c ) dup char+ swap c@ ;

  \ doc{
  \
  \ c@++ ( ca1 -- ca2 c )
  \
  \ Return the character _c_ stored at _ca1_ and increase _ca1_
  \ to point to the next character, resulting _ca2_.
  \
  \ See: `c!++`, `@++`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-18 Added.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-10-25: Improve documentation.
