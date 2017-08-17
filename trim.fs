\ galope/trim.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

require ./minus-leading.fs

: trim ( ca1 len1 -- ca2 len2 ) -leading -trailing ;

\ ==============================================================
\ Change log

\ 2013-10-22 Added.
\
\ 2017-08-17: Update change log layout. Update header.
