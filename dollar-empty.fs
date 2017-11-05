\ galope/dollar-empty.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require string.fs  \ Gforth's dynamic strings

: $empty ( a -- ) 0 swap $!len ;

  \ doc{
  \
  \ $empty ( a -- )
  \
  \ Empty a Gforth's dynamic string variable, setting its length to
  \ zero.
  \
  \ See: `$variable`, `$!new`
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-11-11 Added.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-11-05: Improve documentation.
