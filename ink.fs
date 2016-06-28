\ galope/ink.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ 2012-12-02: Refactored from the "Asalto y castigo" project
\ (<http://programandala.net/es.programa.asalto_y_castigo.forth>).
\ 2012-12-05: Comment; reformatted.
\ 2016-06-26: Change source style. 

require ./sgr.fs

\ Recommended:
\ require ./colors.fs

: ink ( u -- )  1 sgr  ;
  \ Set the current ink (foreground) color to _u_.
