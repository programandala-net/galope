\ galope/home.fs
\ home

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017.

\ ==============================================================

[undefined] home [if]
  : home ( -- ) 0 dup at-xy ;
[then]

  \ doc{
  \
  \ home ( -- )
  \
  \ Move the cursor to the top left position of the screen (row
  \ 0, column 0).
  \
  \ See: `home`, `xy`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-06: First version.
\
\ 2012-09-14: Code reformated.
\
\ 2016-01-16: Updated header and layout.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-10-25: Improve documentation.
\
\ 2017-11-22: Update and improve documentation.
