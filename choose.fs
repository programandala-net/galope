\ galope/choose.fs
\ `choose`
\ Random element of the stack

\ This file is part of Galope

\ Author: Marcos Cruz (programandala.net), 2011, 2012, 2016

\ ==============================================================

require random.fs  \ Gforth's 'random'
require ./drops.fs

: choose  ( x1..xn n -- x' )
  dup >r random pick r> swap >r drops r>  ;
  \ Return an element from the stack, randomly chosen among the _n_
  \ top elements, and remove the rest.

\ ==============================================================
\ History

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
