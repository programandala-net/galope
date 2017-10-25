\ galope/inverted-fetch.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017

\ ==============================================================

require ./inverted.fs

: inverted@ ( a -- x ) dup inverted @ ;

  \ doc{
  \
  \ inverted@ ( a -- x )
  \
  \ Invert all bits of the single-cell number at _a_
  \ and then return the single-cell number _x_ at _a_.
  \
  \ See: `inverted`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-03-06: Moved here from the project "La pistola de agua"
\ (http://programandala.net/es.programa.la_pistola_de_agua.html).
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-10-25: Improve documentation.
