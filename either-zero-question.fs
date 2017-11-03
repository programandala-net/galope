\ galope/either-zero-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017.

\ ==============================================================

: either-zero? ( x1 x2 -- f ) 0= swap 0= or ;

  \ doc{
  \
  \ either-zero?  ( x1 x2 -- f )
  \
  \ If _x1_ is zero or _x2_ is zero, return _true_; otherwise return
  \ _false_.
  \
  \ See: `either-empty?`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-19: Extract `any_zero?` from the <sb.fs> module and rename
\ it.
\
\ 2017-11-03: Fix stack notation. Improve documentation.
