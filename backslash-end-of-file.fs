\ galope/backslash-end-of-file.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2014.

\ Credit: Inspired by SP-Forth.

\ ==============================================================

: \eof ( -- ) source-id if begin refill 0= until then ;

  \ doc{
  \
  \ \eof ( -- )
  \
  \ Ignore the rest of the source file.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-08: Extracted from an application by the author.
\
\ 2012-09-14: Formated.
\
\ 2014-03-02: Formated.
\
\ 2017-08-17: Update change log layout. Update source style.
\
\ 2017-10-24: Improve documentation.
