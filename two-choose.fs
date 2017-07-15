\ galope/two-choose.fs
\ `2choose`
\ Random double element of the stack

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2011, 2012, 2016, 2017.

\ ==============================================================

require random.fs  \ Gforth's 'random'
require ./two-drops.fs

: 2choose  ( d1...dn n -- d' )
  dup >r random 2*  ( d1...dn n' -- ) ( r: n )
  dup 1+ pick swap 2 + pick swap  ( d1...dn dn' -- ) ( r: n )
  r> rot rot 2>r  2drops  2r>  ;
  \ doc{
  \
  \ 2choose  ( d1..dn n -- d' )
  \
  \ Return _d'_, randomly chosen among the _n_ top elements _d1..dn_,
  \ and remove the rest.
  \
  \ See: `choose`.
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

