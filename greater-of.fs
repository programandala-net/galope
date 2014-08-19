\ galope/greater-of.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ 2014-02-12: Written.
\ 2014-02-15: '>r dup dup r>' changed to 'nup nup'.
\ 2014-03-12: Usage example.

require ./nup.fs

: (greater-of)  ( x1 x2 -- x1 x1 | x1 x1' )
  nup nup <= if  invert  then
  ;
: greater-of  ( compilation: -- of-sys ) ( run-time: x1 x2 -- | x1 )
  postpone (greater-of) postpone of
  ;  immediate compile-only

0 [if]

\ Usage example

: test  ( x -- )
  case
    10 of  ." ten!"  endof
    15 greater-of  ." greater than 15"  endof
    ." less than 10 or 11..15"
  endcase
  ;

[then]
