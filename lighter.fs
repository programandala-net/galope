\ galope/lighter.fs
\ `lighter`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017

\ ==============================================================

require ffl/trm.fs

: lighter ( x1 -- x2 )
  [ trm.foreground-black-high trm.foreground-black - ] literal +  ;

  \ doc{
  \
  \ Change a color code _x1_ to its lighter counterpart _x2_.
  \
  \ See: `blue`, `light-blue`, `brown`, `cyan`, `light-cyan`, `green`,
  \ `light-green`, `gray`, `light-gray`, `magenta`, `light-magenta`,
  \ `red`, `light-red`, `white`, `yellow`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-12-02: Extracte from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\
\ 2016-07-11: Update source layout and file header.
\
\ 2017-10-25: Improve documentation.
