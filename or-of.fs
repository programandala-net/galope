\ galope/or-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ 2014-03-13: Written.

: (or-of)  ( x1 x2 x3 -- x1 x1 | x1 x1' )
  2>r dup dup dup r> = swap r> = or 0= if  invert  then
  ;
: or-of  ( compilation: -- of-sys ) ( run-time: x1 x2 x3 -- | x1 )
  postpone (or-of) postpone of
  ;  immediate compile-only

0 [if]

\ Usage example

: test  ( x -- )
  case
    1 of  ." one"  endof
    2 3 or-of  ." two or three"  endof
    4 of  ." four"  endof
  endcase
  ;

[then]
