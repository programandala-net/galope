\ galope/random-range.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2017.

\ ==============================================================

require galope/random-within.fs

: random-range ( n1 n2 -- n3 ) 1+ random-within ;

  \ doc{
  \
  \ random-range ( n1 n2 -- n3 )
  \
  \ Return a random number _n3_ from _n1_ (minimum) to _n2_
  \ (maximum).
  \
  \ See: `random-within`, `randomize`.
  \
  \ }doc

\ ==============================================================
\ Benchmark

true [if]

require random.fs
require ./benched.fs
require ./random-within.fs

: v1 ( n1 n2 -- n3 ) over - 1+ random + ;

: v2 ( n1 n2 -- n3 ) 1+ random-within ;

: v3 ( n1 n2 -- n3 ) 1+ over - rnd swap mod + ;

variable counter

: bench1 ( n -- ) 0 ?do 0 100 v1 drop loop ;
: bench2 ( n -- ) 0 ?do 0 100 v2 drop loop ;
: bench3 ( n -- ) 0 ?do 0 100 v3 drop loop ;

: bench ( n -- )
  dup cr ." Iterations = " .
  dup cr ." v1 = " bench{ bench1 }bench. cr
  dup cr ." v2 = " bench{ bench1 }bench. cr
      cr ." v3 = " bench{ bench3 }bench. cr ;

  \ 2017-11-22:
  \
  \ Iterations    ms v1   ms v2   ms v3
  \ ----------    -----   -----   -----
  \       1          11       3*      6
  \       1          11       4*      6
  \      10          15       7*     11
  \      10          21      10*    101
  \      10          24      10*     16
  \     100          91      80*    103
  \     100          93      83*    108
  \    1000         795     784*    971
  \    1000         794     785*    971
  \    1000         532     522*    648
  \   10000        8627    8121*  17888
  \   10000        7859*   8993   22327
  \   10000        8049*   9107    9980
  \ 1000000       85191   59609   55244*
  \ 1000000       54347   52997*  65523

[then]

\ ==============================================================
\ Change log

\ 2013-08-16: Written as `/random/`.
\
\ 2014-05-22: Rewritten and improved as `random-range`.
\
\ 2017-08-17: Update change log layout. Update source style.
\
\ 2017-11-09: Improve documentation.
\
\ 2017-11-22: Fix and update documentation. Benchmark three
\ variants. Rewrite after `random-within`.
