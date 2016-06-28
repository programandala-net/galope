\ galope/paper.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ 2012-12-02: Refactored from the "Asalto y castigo" project
\ (<http://programandala.net/es.programa.asalto_y_castigo.forth>).
\
\ 2012-12-05: Comment; reformatted.
\
\ 2016-06-28: Update file header and source style.

require ./sgr.fs

\ Recommended:
\ require ./colors.fs

: paper  ( u -- )  10 + 1 sgr  ;
  \ Set the current paper (background) color.
