\ galope/two-choose.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2011, 2012, 2016, 2017,
\ 2018.

\ ==============================================================

require random.fs \ Gforth's 'random'
require ./two-drops.fs

: 2choose ( xd[u-1]..xd[0] u -- xd )
  dup >r random 2pick r> rot rot 2>r 2drops 2r> ;

  \ doc{
  \
  \ 2choose ( xd[u]..xd[0] u -- xd[x] )
  \
  \ Return _xd_, randomly chosen among the _u_ top elements _xd[u]..dn_,
  \ and remove the rest.
  \
  \ See: `choose`, `2pick`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-04-07: Extracted from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\
\ 2012-05-01: Divided in two files: choose.fs and 2choose.fs.
\
\ 2012-09-19: '2mdrop' updated to '2drops'.
\
\ 2016-07-11: Update source layout and file header.
\
\ 2017-07-14: Improve documentation.
\
\ 2018-07-24: Update source style. Improve documentation.
