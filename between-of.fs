\ galope/between-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ 2014-02-10: Written.
\ 2014-02-12: Renamed from "range-of" to "between-of", in order to
\   write also "within-of", so both definitions are clear.
\ 2014-03-13: Usage example.

require ./between.fs

: (between-of)  ( x1 x2 x3 -- x1 x1 | x1 x1' )
  2>r dup dup 2r> between 0= if  invert  then
  ;
: between-of  ( compilation: -- of-sys ) ( run-time: x1 x2 x3 -- | x1 )
  postpone (between-of) postpone of
  ;  immediate compile-only

0 [if]

\ Usage example

: test  ( x -- )
  case
    1 of ." one"  endof
    2 5 between-of  ." between two and five"  endof
    6 of ." six"  endof
  endcase
  ;

[then]
