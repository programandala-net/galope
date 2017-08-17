\ galope/two-rolls.fs
\ Double multiple roll

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ System dependencies: Gforth's 'u+do'.

\ 2012-04-30 First version.
\ 2012-09-14 Renamed to '2rolls' (formerly ' 2mroll').

require ./two-roll.fs

: 2rolls ( d0 d1 ... dn n -- dn ... d1 d0 )
  1 u+do  i 2roll  loop
  ;

