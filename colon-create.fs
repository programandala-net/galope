\ galope/colon-create.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: :create ( ca len -- ) nextname create ;

  \ doc{
  \
  \ :create ( ca len -- )
  \
  \ Create a ``create`` word with name _ca len_.
  \
  \ See: `:constant`, `:svariable`, `:$variable`, `:alias`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo).
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-10-26: Improve documentation.
