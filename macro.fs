\ galope/macro.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Wil Baden.

\ ==============================================================

: macro ( "name <char> ccc<char>" -- )
  : char parse
  postpone sliteral
  postpone evaluate
  postpone ; immediate ;

\ ==============================================================
\ Change log

\ 2012-05-06 Added.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
