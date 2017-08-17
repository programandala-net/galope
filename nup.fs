\ galope/nup.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: nup ( x1 x2 -- x1 x1 x2 ) over swap ;

\ ==============================================================
\ Benchmarks

false [if]

: nup1  ( x1 x2 -- x1 x1 x2 ) >r dup r> ;

: nup2  ( x1 x2 -- x1 x1 x2 ) over swap ;

defer nupx

: (nuptest)  { times -- }
  utime
  1 2
  times 0 do  nupx drop  loop
  utime swap - u. ." microseconds" cr ;

: nuptest  { times -- }
  ['] nup1 is nupx times (nuptest)
  ['] nup2 is nupx times (nuptest) ;

\ Result on Raspberry Pi with Raspbian:
\ cr 10000000 nuptest
\ 531217218 microseconds
\ 528703805 microseconds

[then]

\ ==============================================================
\ Change log

\ 2014-02-15: Common usage word, after suggestion of Rod Pemberton in:
\ <news:/comp.lang.forth>, Date: Fri, 14 Feb 2014 20:44:22 -0500,
\ Message-ID: <op.xbau38lc5zc71u@localhost>.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
