\ galope/inverted-fetch.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017, 2018.

\ ==============================================================

require ./inverted.fs

: inverted@ ( a -- x ) dup inverted @ ;

  \ doc{
  \
  \ inverted@ ( a -- x )
  \
  \ Invert all bits of the cell stored at _a_
  \ and fetch the result _x_.
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
\
\ 2018-07-24: Improve the description.
