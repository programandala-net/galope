\ galope/choose.fs
\ Random element of the stack

\ This file is part of Galope

\ Copyright (C) 2011,2012 Marcos Cruz (programandala.net)

\ History

(

2012-04-07 In order to reuse this code, it was extracted from
  the project it was developed for
  [http://programandala.net/es.programa.asalto_y_castigo.forth].
2012-05-01 Divided in two files: choose.fs and 2choose.fs.
2012-09-14 Code and comments reformated.
2012-09-19 'mdrop' updated to 'drops'.

) 

require random.fs  \ Gforth's 'random'
require ./drops.fs

: choose  ( x1..xn n -- xn' )

  \ Return a double element from the stack, randomly chosen
  \ among the n top elements, and remove the rest.

  dup >r random pick r> swap >r drops r>
  ;
