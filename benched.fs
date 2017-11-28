\ galope/benched.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017.

\ ==============================================================
\ Credits

\ Code adapted from Solo Forth.  The Solo Forth version was
\ adapted from Forth Dimensions (volume 17, number 4 page 11,
\ 1995-11).

\ ==============================================================

2variable bench0

: bench{ ( -- ) utime bench0 2! ;

  \ doc{
  \
  \ bench{ ( -- )
  \
  \ Mark the start of a benchmark.
  \
  \ See also: `}bench`, `}bench.`.
  \
  \ }doc

: }bench ( -- d ) utime bench0 2@ d- ;

  \ doc{
  \
  \ }bench ( -- d )
  \
  \ Mark the end of a benchmark that was started by `bench{`
  \ and leave the result _d_ in microseconds.
  \
  \ See also: `}bench.`.
  \
  \ }doc

: bench. ( d -- ) d. ." ms" ;

  \ doc{
  \
  \ bench. ( d -- )
  \
  \ Display the result _d_ in microseconds of a benchmark, left
  \ by `}bench` or `benched`.
  \
  \ See also: `bench{`, `}bench.`.
  \
  \ }doc

: }bench. ( -- ) }bench bench. ;

  \ doc{
  \
  \ }bench. ( -- )
  \
  \ Mark the end of a benchmark that was started by `bench{`
  \ and display the result in microseconds.
  \
  \ See also: `}bench`, `bench.`.
  \
  \ }doc

: benched ( xt n -- d )
  bench{ 0 do dup execute loop }bench rot drop ;

  \ doc{
  \
  \ benched ( xt n -- d )
  \
  \ Benchmark _xt_ by executing it _n_ times.
  \
  \ NOTE: A copy of _xt_ is on the stack when _xt_ is executed.
  \
  \ See also: `bench{`, `}bench`.
  \
  \ }doc

: benched. ( xt n -- )
  bench{ 0 do dup execute loop }bench. drop ;

  \ doc{
  \
  \ benched. ( xt n -- )
  \
  \ Benchmark _xt_ by executing it _n_ times and display the
  \ result in microseconds.
  \
  \ NOTE: A copy of _xt_ is on the stack when _xt_ is executed.
  \
  \ See also: `bench{`, `}bench.`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-03-15: Added.
\
\ 2017-08-17: Update change log layout.
\
\ 2017-11-28: Improve documentation.
