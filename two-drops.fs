\ galope/two-drops.fs
\ Double multiple drop

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ ==============================================================

require ./drops.fs

: 2drops ( d1 ... dn n -- ) 2* drops ;

\ ==============================================================
\ Change log

\ 2012-04-30 Extracted from mdrop.fs.
\
\ 2012-09-14 Renamed to '2drops'.
\
\ 2017-08-17: Update change log layout. Update header.
