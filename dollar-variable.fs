\ galope/dollar-variable.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2015, 2017.

\ ==============================================================

require string.fs  \ Gforth's dynamic strings

: $variable ( "name" -- )
  variable 0 latestxt execute $!len ;

  \ doc{
  \
  \ $variable ( "name" -- )
  \
  \ Create a Gforth's dynamic string variable _name_
  \
  \ See: `:$variable`, `svariable`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-11-09: Added.
\
\ 2015-04-15: Simpler.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-10-26: Improve documentation.
