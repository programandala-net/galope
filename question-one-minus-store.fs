\ galope/question-one-minus-store.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Brad Rodriguez, 2012
\ (http://camelforth.com/news.php?extend.44.2)

\ ==============================================================

: ?1-! ( a -- ) dup @ ?dup if 1- swap ! else drop then ;

  \ doc{
  \
  \ ?1-! ( a -- )
  \
  \ Decrement the single-cell number at _a_ to, but not beyond, zero.
  \
  \ See: `1-!` ,`?1+!`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-12 Added. Code by Brad Rodriguez:
\ <http://camelforth.com/news.php?extend.44.2>.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-10-25: Improve documentation.
\
\ 2017-11-09: Rename `decrement` `?1-!`. Deprecate `decrement` as a
\ synonym, in its own module. Improve documentation.
