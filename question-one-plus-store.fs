\ galope/question-one-plus-store.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

: ?1+! ( a -- ) dup @ 1+ 0>= abs swap +! ;

  \ doc{
  \
  \ ?1+! ( a -- )
  \
  \ Increment the single-cell number at _a_ to, but not beyond, the
  \ largest usable signed integer.
  \
  \ See: `max-n`, `1+!`, `?1-!`, `?1+`.
  \
  \ }doc

\ ==============================================================
\ Benchmark

false [if]

require ./max-n.fs
require ./one-plus-store.fs
require ./benched.fs

: ?1+!v1 ( a -- ) dup @ 1+ 0>= abs swap +! ;

: ?1+!v2 ( a -- ) dup @ max-n = if drop else 1+! then ;

variable counter

: bench1 ( n -- ) counter off 0 ?do counter ?1+!v1 loop ;
: bench2 ( n -- ) counter off 0 ?do counter ?1+!v2 loop ;

: bench ( n -- )
  dup cr ." Iterations = " .
  dup cr ." v1 = " bench{ bench1 }bench. cr
      cr ." v2 = " bench{ bench2 }bench. cr ;

  \ 2017-11-12:
  \
  \ Iterations    ms v1   ms v2
  \ ----------    -----   -----
  \       1           5       4
  \       1           6       3
  \       1           7       5
  \       1           8       5
  \      10           6       5
  \      10           7       5
  \      10           8       7
  \      10           9       7
  \      20          10      10
  \      20          11      10
  \      20          11      11
  \      20          12      10
  \     100          19      23
  \     100          27      33
  \     100          28      34
  \     100          25      34
  \    1000         103     201
  \    1000         132     199
  \    1000         196     299
  \   10000        1097    3024
  \ 1000000      131061  198350

[then]

\ ==============================================================
\ Change log

\ 2017-11-09: Start.
\
\ 2017-11-12: Replace with the definition of the deprecated `?++`,
\ which already existed and was faster. Benchmark.  (`?++` was moved
\ and improved on 2016-07-11 from "Asalto y castigo":
\ http://programandala.net/en.program.asalto_y_castigo.forth.html).
\
\ 2017-11-22: Update documentation.
