\ galope/lighter.fs
\ `lighter`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016

\ ==============================================================

require ffl/trm.fs

: lighter  ( n1 -- n2 )
  [ trm.foreground-black-high trm.foreground-black - ] literal +  ;
  \ Change a color code to its lighter counterpart.

\ ==============================================================
\ Change log

\ 2012-12-02: Extracte from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\
\ 2016-07-11: Update source layout and file header.
