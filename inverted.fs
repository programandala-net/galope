\ galope/inverted.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ 2014-03-06: Moved here from the project "La pistola de agua"
\ (<http://programandala.net/en.program.la_pistola_de_agua.html>)

: inverted  ( a -- )
  \ Invert the content of a variable.
  dup @ invert swap !
  ;
