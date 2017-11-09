\ galope/randomize.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2017.

\ ==============================================================

require random.fs  \ Gforth's 'random'

: randomize ( -- ) utime * seed ! ;

  \ doc{
  \
  \ randomize ( -- )
  \
  \ Set the ``random``'s ``seed`` using the values returned by
  \ ``utime``.
  \
  \ See: `random-range`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-08-30 Change: 'utime' instead of 'time&date'.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-11-09: Improve documentation.
