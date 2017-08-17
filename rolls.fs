\ galope/rolls.fs
\ Multiple roll

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ ==============================================================

\ XXX TODO -- System dependencies: Gforth's 'u+do'.

: rolls ( x0 x1 ... xn n -- xn ... x1 x0 )
  1 u+do i roll loop ;

\ ==============================================================
\ Change log

\ 2012-04-30 First version, 'mroll'.
\
\ 2012-09-14 Renamed to 'rolls' (formerly 'mroll').
\
\ 2017-08-17: Update change log layout.
