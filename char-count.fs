\ galope/char-count.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ ==============================================================

: char-count  ( ca len c -- n )
  0 2swap bounds ?do over i c@ = abs + loop nip ;
  \ Count the number of occurrences of the char c in the string ca len.

\ ==============================================================
\ Change log

\ 2013-12-06: First version.
\
\ 2015-10-13: Renamed.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
