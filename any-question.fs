\ galope/any-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author:
\   John A. Peters, 1984.
\   Included in a tool set written for the
\   CP/M implementation of Laxen&Perry's F83 2.1.1.

\ ==============================================================

variable (any?)

: any? ( x#0 x#1 .. x#n n -- f )
  dup 1+ roll (any?) ! 0 swap 0 ?do swap (any?) @ = or loop ;

  \ doc{
  \
  \ any? ( x#0 x#1 .. x#n n -- f )
  \
  \ Is any _x#1 .. x#n_ equal to _x#0_?
  \
  \ See: `any-of`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2015-12-11: Copy from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html). Original code
\ from John A. Peters' tools for CP/M F83 2.1.1.
\
\ 2016-07-11: Update source layout and file header. Fix and complete
\ the credits.
\
\ 2017-08-17: Update header layout.
\
\ 2017-10-24: Improve documentation.
\
\ 2017-11-14: Improve documentation. Replace `do` with `?do`.
