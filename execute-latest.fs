\ galope/execute-latest.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

: execute-latest ( -- ) latest name>int execute ;

  \ doc{
  \
  \ execute-latest ( -- )
  \
  \ Execute the interpretation semantics of the latest word created.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-02-18: Moved from <galope/module.fs> and renamed.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-10-26: Improve documentation.
