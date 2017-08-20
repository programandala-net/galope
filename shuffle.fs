\ galope/shuffle.fs
\ `shuffle`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017.

\ ==============================================================

require random.fs \ Gforth's `random`

0 value (shuffle#)

: shuffle ( x1 ... xn n -- x1' ... xn' )
  dup to (shuffle#) 0 ?do (shuffle#) random roll loop ;
  \ Shuffle _n_ items of the stack.

\ ==============================================================
\ Change log

\ 2016-07-11: Move from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html)
\ and rename.
\
\ 2017-08-17: Fix change log title. Update header and source style.
