\ galope/lighter.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-12-02 Refactored from the "Asalto y castigo" project
\ (<http://programandala.net/es.programa.asalto_y_castigo.forth>).

require ffl/trm.fs

: lighter  ( u1 -- u2 )
  \ Change a color code to its lighter counterpart.
  [ trm.foreground-black-high trm.foreground-black - ] literal +
  ;
