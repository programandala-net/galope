\ galope/svariable.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2014, 2016,
\ 2017.

\ ==============================================================

require ./slash-counted-string.fs

: svariable ( "name" -- )
  create 0 c, /counted-string allot align  ;

  \ doc{
  \
  \ svariable ( "name" -- )
  \
  \ Create a string variable _name_ which will return the address of
  \ its contents, stored in data space, as a counted string. The
  \ maximum length of the string is `/counted-string`.
  \
  \ Usage example:
  \
  \ ----

  \ svariable my-string
  \ s" Hello" my-string place
  \ my-string count type

  \ ----
  \
  \ See: `:svariable`, `$variable`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012: First version.
\
\ 2013-11-25: Factored out with `/counted-string`.
\
\ 2014-01-29: Fix: "./" path for `require`.
\
\ 2016-06-26: Update style and header.
\
\ 2016-07-11: Update source layout and comment.
\
\ 2017-10-26: Improve documentation.
\
\ 2017-11-04: Fix documentation markup.
\
\ 2017-11-04: Rename module after the general convention, ie.
\ <s-variable.fs>.
