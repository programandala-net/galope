\ galope/minus-minus.fs
\ Decrement the content of an address

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017

\ ==============================================================

: -- ( a -- ) -1 swap +! ;

  \ doc{
  \
  \ -- ( a -- )
  \
  \ Decrement the single-cell number at _a_.
  \
  \ See: `++`, `decrement`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-05: First version.
\
\ 2012-05-07: File renamed.
\
\ 2012-09-14: Code reformated.
\
\ 2016-01-16: Updated header and layout.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-10-25: Improve documentation.
