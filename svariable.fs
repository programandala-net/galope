\ galope/svariable.fs
\ `svariable`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ By Marcos Cruz (programandala.net), 2012, 2013, 2014, 2016.

\ ==============================================================

require ./slash-counted-string.fs

: svariable  ( "name" -- )
  create 0 c, /counted-string allot align  ;
  \ Create a string variable _name_ which will return the address of
  \ its contents, as a counted string.

\ ==============================================================
\ History

\ 2012: First version.
\
\ 2013-11-25: Factored out with `/counted-string`.
\
\ 2014-01-29: Fix: "./" path for `require`.
\
\ 2016-06-26: Update style and header.
\
\ 2016-07-11: Update source layout and comment.
