\ galope/colon-dollar-variable.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require ./dollar-variable.fs

: :$variable ( ca len -- ) nextname $variable ;

  \ doc{
  \
  \ :$variable ( ca len -- )
  \
  \ Create a Gforth's dynamic string variable with name _ca len_.
  \
  \ See: `$variable`, `:svariable`, `:create`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-12-01 Added.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-10-26: Improve documentation.
