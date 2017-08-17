\ galope/backslash-end-of-file.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012,2014 Marcos Cruz (programandala.net)

\ ==============================================================

: \eof  ( -- )
  source-id if begin refill 0= until then ;
  \ Ignore the rest of the source file.
  \ Inspired by SP-Forth.

\ ==============================================================
\ Change log

\ 2012-05-08: Extracted from an application by the author.
\
\ 2012-09-14: Formated.
\
\ 2014-03-02: Formated.
\
\ 2017-08-17: Update change log layout. Update source style.
