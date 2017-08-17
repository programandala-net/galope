\ galope/paper.fs
\ `paper`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ ==============================================================

require ./sgr.fs

: paper  ( n -- )  10 + 1 sgr  ;
  \ Set the current paper (background) color.

\ ==============================================================
\ Change log

\ 2012-12-02: Extract from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\
\ 2012-12-05: Add comment; reformat.
\
\ 2016-06-28: Update file header and source style.
\
\ 2016-07-11: Update source layout and file header.
