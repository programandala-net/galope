\ galope/question-perform.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./question-execute.fs

: ?perform ( a -- )
  @ ?execute ;

  \ doc{
  \
  \ ?perform ( a -- )
  \
  \ Fetch the the cell stored at _a_. If it's zero, discard it.
  \ Otherwise consider it an execution token and call ``execute``.
  \
  \ See: `?execute`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-08-03: Add to the library.
\
\ 2017-08-14: Update documentation notation.
