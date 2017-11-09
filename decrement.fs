\ galope/decrement.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Brad Rodriguez, 2012
\ (http://camelforth.com/news.php?extend.44.2)

\ ==============================================================

require ./question-one-minus-store.fs

synonym decrement ?1-! ( -- )

  \ doc{
  \
  \ decrement ( a -- )
  \
  \ Decrement the single-cell number at _a_ to, but not beyond, zero.
  \
  \ ``decrement`` is deprecated, but it's kept as a synonym of `?1-!`.
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
\ 2017-11-09: Move code to `?1-!`. Deprecate `decrement` and make it a
\ synonym of `?1-!`.
