\ galope/either-empty-question.fs
\ `either-empty?`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ ==============================================================

require ./both-lengths.fs
require ./either-empty-question.fs

: either-empty?  ( ca1 len1 ca2 len2  -- ca1 len1 ca2 len2 f )
  both-lengths either-zero?  ;

\ ==============================================================
\ History

\ 2016-07-19: Extract `any_empty?` from the <sb.fs> module and rename
\ it.

