\ galope/inverted.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

: inverted ( a -- ) dup @ invert swap ! ;
  \ Invert the content of a variable.

\ ==============================================================
\ Change log

\ 2014-03-06: Moved here from the project "La pistola de agua"
\ (http://programandala.net/en.program.la_pistola_de_agua.html).
\
\ 2017-08-17: Update change log layout and source style.
