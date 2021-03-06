\ galope/decrement.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./question-one-minus-store.fs
require ./warning-paren.fs

warnings @ [if]

  warning( `decrement` is the deprecated name of `?1-!`)

[then]

synonym decrement ?1-! ( -- )

  \ doc{
  \
  \ decrement ( a -- )
  \
  \ Decrement the single-cell number at _a_ to, but not beyond, zero.
  \
  \ NOTE: ``decrement`` is deprecated, replaced by `?1-!`.
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
\
\ 2017-11-14: Add a warning about the deprecation.
\
\ 2017-11-15: Update header.
\
\ 2017-11-22: Improve documentation.
