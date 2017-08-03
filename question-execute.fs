\ galope/question-execute.fs
\ `?execute`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2016, 2017.

\ ==============================================================

: ?execute ( xt | 0 -- )
  ?dup if execute then ;

  \ doc{
  \
  \ ?execute ( xt | 0 -- )
  \
  \ If TOS is zero, discard it.  Otherwise call ``execute``.
  \
  \ See also: `?perform`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-02-17: Add to the library.
\
\ 2016-07-11: Update source layout and file header.
\
\ 2017-08-03: Update source style. Improve documentation
