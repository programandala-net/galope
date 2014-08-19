\ galope/backslash-end-of-file.fs

\ This file is part of Galope

\ Copyright (C) 2012,2014 Marcos Cruz (programandala.net)

\ History
\ 2012-05-08: Extracted from an application by the author.
\ 2012-09-14: Formated.
\ 2014-03-02: Formated.

: \eof  ( -- )
  \ Ignore the rest of the source file.
  \ Inspired by SP-Forth.
  source-id if  begin  refill 0=  until  then
  ;
