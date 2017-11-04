\ galope/colon-s-variable.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require ./s-variable.fs

: :svariable ( ca len -- ) nextname svariable ;

  \ doc{
  \
  \ :svariable ( ca len -- )
  \
  \ Create a string variable with name _ca len_.
  \
  \ Usage example:
  \ ----

  \ s" my-string" :svariable
  \ s" Hello" my-string place
  \ my-string count type

  \ ----
  \
  \ See: `svariable`, `:$variable`, `:create`, `:alias`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-10-26: Improve documentation.
\
\ 2017-11-04: Rename module after the general convention, ie.
\ <colon-s-variable.fs>.  Update filename of `svariable`.
