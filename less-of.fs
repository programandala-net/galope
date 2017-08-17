\ galope/less-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ 2014-02-12: Written.
\ 2014-02-15: '>r dup dup r>' changed to 'nup nup'.
\ 2014-03-12: Usage example.

require ./nup.fs

: (less-of)  ( x1 x2 -- x1 x1 | x1 x1' )
  nup nup >= if  invert  then
  ;
: less-of  ( compilation: -- of-sys ) ( run-time: x1 x2 -- | x1 )
  postpone (less-of) postpone of
  ;  immediate compile-only

0 [if]

\ Usage example

: test  ( x -- )
  case
    10 of  ." ten!"  endof
    15 less-of  ." less than 15"  endof
    ." greater than 14"
  endcase
  ;

[then]
