\ galope/ink.fs
\ `ink`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ ==============================================================

require ./sgr.fs

: ink ( n -- )  1 sgr  ;
  \ Set the current ink (foreground) color to _n_.

\ ==============================================================
\ Change log

\ 2012-12-02: Refactored from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\
\ 2012-12-05: Comment; reformatted.
\
\ 2016-06-26: Change source style.
