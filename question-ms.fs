\ galope/question-ms.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require ./question-microseconds.fs

: ?ms ( u -- ) 1000 * ?microseconds ;

  \ doc{
  \
  \ ?ms ( u -- )
  \
  \ Wait at least _u_ miliseconds or until a key is pressed.
  \
  \ See: `?microseconds`, `?seconds`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-06-18: Taken from the program Autohipnosis, by the same author
\ (http://programandala.net/es.program.autohipnosis).
\
\ 2012-09-14: Code reformated.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-12-04: Rename `miliseconds` `?ms`.
