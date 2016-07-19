\ galope/both-lengths.fs
\ `both-lengths`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ ==============================================================

: both-lengths  ( ca1 len1 ca2 len2 -- ca1 len1 ca2 len2 len1 len2 )
  2 pick over  ;

\ ==============================================================
\ History

\ 2016-07-19: Extract `lengths` from the <sb.fs> module and rename it.

