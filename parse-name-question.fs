\ galope/parse-name-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013.

\ ==============================================================

: parse-name? ( "name" -- ca len f ) parse-name dup 0= ;
  \ Parse the next name in the source.
  \ ca len = parsed name
  \ f = empty name?
  \ Typical usage:
  \   parse-name? abort" Missing name"

\ ==============================================================
\ Change log

\ 2013-07-09 Added.
\
\ 2013-11-06 Changed the stack notation of flag.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ stle. Update stack notation.
