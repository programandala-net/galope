\ galope/either-empty-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017.

\ ==============================================================

require ./both-lengths.fs
require ./either-zero-question.fs

: either-empty? ( ca1 len1 ca2 len2  -- ca1 len1 ca2 len2 f )
  both-lengths either-zero? ;

  \ doc{
  \
  \ either-empty? ( ca1 len1 ca2 len2  -- ca1 len1 ca2 len2 f )
  \
  \ If _len1_ is zero or _len2_ is zero, return _true_; otherwise
  \ return _false_.
  \
  \ See: `either-zero?`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-19: Extract `any_empty?` from the <sb.fs> module and rename
\ it.
\
\ 2017-11-03: Improve documentation.
