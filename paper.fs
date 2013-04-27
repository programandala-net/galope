\ galope/paper.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-12-02 Refactored from the "Asalto y castigo" project
\ (<http://programandala.net/es.programa.asalto_y_castigo.forth>).
\ 2012-12-05 Comment; reformatted.

require galope/sgr.fs

\ Recommended:
\ require galope/colors.fs

: paper  ( u -- )
  \ Set the current paper (background) color.
  10 + 1 sgr
  ;
