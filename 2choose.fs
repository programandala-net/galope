\ galope/2choose.fs
\ Random double element of the stack

\ This file is part of Galope

\ Copyright (C) 2011,2012 Marcos Cruz (programandala.net)

\ History

(

2012-04-07 Extracted from the project it was developed for
  [http://programandala.net/es.programa.asalto_y_castigo.forth].
2012-05-01 Divided in two files: choose.fs and 2choose.fs.
2012-09-19 '2mdrop' updated to '2drops'.

) 

require random.fs  \ Gforth's 'random'
require ./2drops.fs

: 2choose  ( d1...dn n -- dn' )

  \ Return a double element from the stack, randomly chosen
  \ among the n top elements, and remove the rest.

  dup >r random 2*  ( d1...dn n' -- ) ( r: n )
  dup 1+ pick swap 2 + pick swap  ( d1...dn dn' -- ) ( r: n )
  r> rot rot 2>r  2drops  2r>
  ;

