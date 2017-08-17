\ galope/seconds.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ ==============================================================

require ./microseconds.fs

: seconds  ( u -- )
  \ Wait a number of seconds or until a key is pressed.
  1000000 * microseconds ;

\ ==============================================================
\ Change log

\ 2012-06-18 Taken from the Autohipnosis program
\ (http://programandala.net/es.programa.autohipnosis).
\
\ 2017-08-17: Update change log layout. Update header.
