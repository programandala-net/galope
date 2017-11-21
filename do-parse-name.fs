\ galope/do-parse-name.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./question-throw.fs

: do-parse-name ( "name" -- ca len )
  begin  parse-name dup 0=
  while  2drop refill 0= -39 ?throw
  repeat ;

  \ doc{
  \
  \ do-parse-name ( "name" -- ca len )
  \
  \ Parse _name_, using ``refill`` if needed, and return _name_
  \ as string _ca len_ in the input buffer.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-21: Move from _La pistola de agua_
\ (http://programandala.net/es.programa.la_pistola_de_agua.html).
