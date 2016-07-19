\ galope/either-zero-question.fs
\ `either-zero?`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ ==============================================================

: either-zero?  ( n1 n2 -- f )  0= swap 0= or  ;

\ ==============================================================
\ History

\ 2016-07-19: Extract `any_zero?` from the <sb.fs> module and rename
\ it.

