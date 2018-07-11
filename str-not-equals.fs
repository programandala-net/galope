\ galope/str-not-equals.fs
\ str<>

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: str<> ( ca1 len1 ca2 len2 -- f ) compare 0<> ;
  \ Are two strings different?


  \ doc{
  \
  \ str<> ( ca1 len1 ca2 len2 -- f )
  \
  \ Is string _ca1 len1_ different from string _ca2 len2_?
  \
  \ See: `pair=`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)
\
\ 2017-08-17: Update change log layout. Update header. Update stack
\ notation. Update source style.
\
\ 2018-07-11: Improve documentation.
