\ galope/question-seconds.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require ./question-microseconds.fs

: ?seconds ( u -- ) 1000000 * ?microseconds ;

  \ doc{
  \
  \ ?seconds ( u -- )
  \
  \ Wait at least _u_ seconds or until a key is pressed.
  \
  \ See: `?microseconds`, `?ms`, `seconds`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-06-18 Taken from the Autohipnosis program
\ (http://programandala.net/es.programa.autohipnosis).
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-12-04: Rename `seconds` `?seconds`, after Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
