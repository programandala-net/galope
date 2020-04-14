\ galope/tilde-tilde.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2014, 2017, 2020.

\ ==============================================================

here ," CHECK POINT compiled in " constant ~~title

warnings @ warnings off

: ~~  ( -- )
  postpone ~~title postpone count
  postpone cr postpone type
  latest postpone literal postpone .name
  postpone ~~ postpone key postpone drop
  ; immediate

  \ doc{
  \
  \ ~~  ( -- )
  \
  \ Improved version of Gforth's ``~~``, which displays a clearer
  \ message and waits for a key press.
  \
  \ }doc

warnings !

\ ==============================================================
\ Change log

\ 2012-05-19: Taken from another project of the author.
\
\ 2014-03-02: 'warnings' is preserved and turned off.
\
\ 2017-08-17: Update change log layout.
\
\ 2020-04-11: Update source style.
\
\ 2020-04-14: Improve documentation.
