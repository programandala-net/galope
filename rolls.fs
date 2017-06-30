\ galope/rolls.fs
\ Multiple roll

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ System dependencies: Gforth's 'u+do'.

\ History
\ 2012-04-30 First version, 'mroll'.
\ 2012-09-14 Renamed to 'rolls' (formerly 'mroll').

: rolls ( x0 x1 ... xn n -- xn ... x1 x0 )
  1 u+do i roll loop
  ;

