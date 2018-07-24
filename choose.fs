\ galope/choose.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2011, 2012, 2016, 2017,
\ 2018.

\ ==============================================================

require random.fs \ Gforth's 'random'
require ./drops.fs

: choose ( x[u-1]..x[0] u -- x )
  dup >r random pick r> swap >r drops r> ;

  \ doc{
  \
  \ choose ( x[u-1]..x[0] u -- x )
  \
  \ Return _x_, randomly chosen among the _u_ top elements
  \ _x[u-1]..x[0]_, and remove the rest.
  \
  \ See: `2choose`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-04-07: Extract from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\
\ 2012-05-01: Split in two files: <choose.fs> and <2choose.fs>.
\
\ 2012-09-14: Reformat code and comments.
\
\ 2012-09-19: Update 'mdrop' to 'drops'.
\
\ 2016-07-11: Update source layout and file header, fix comment.
\
\ 2017-07-14: Improve documentation.
\
\ 2018-07-24: Update source style. Improve documentation.
