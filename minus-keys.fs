\ galope/minus-keys.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017

\ ==============================================================

: -keys ( -- ) begin key? while key drop repeat ;

  \ doc{
  \
  \ -keys ( -- )
  \
  \ Remove all keys from the keyboard buffer.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-09-30: Start.
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style. Remove `module`.
\
\ 2017-11-04: Improve documentation.
