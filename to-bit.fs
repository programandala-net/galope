\ galope/to-bit.fs
\ `>bit`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017.

\ ==============================================================

: >bit ( n -- x ) 1 swap lshift ;
  \ Convert bit number _n_ to its bit mask _n_.

\ ==============================================================
\ Change log

\ 2016-07-14: Move from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\
\ 2016-07-19: Update stack notation.
\
\ 2017-08-17: Update source style.
