\ galope/queue.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ ==============================================================

\ XXX FIXME the two cells of a double are listed by '.queue' in
\ different order than on the stack by '.s'.

: queue ( n "name" -- )
  \ Create a named queue with a maximum size in address units.
  create dup allocate throw
    ,    \ address
    0 ,  \ size
    ,    \ n = maximum size
  ;
' noop alias queue>a  ( queue -- a )
' cell+ alias queue>len  ( queue -- a )
: queue>max  ( queue -- a )
  2 cells +
  ;
: queue@a  ( queue -- a )
  \ Current address of a queue.
  queue>a @
  ;
: queue@len  ( queue -- len )
  \ Current length of a queue.
  queue>len @
  ;
: queue@max  ( queue -- len )
  \ Maximum size of a queue.
  queue>max @
  ;
: queue>  ( queue -- a )
  \ Free space address of a queue.
  dup queue@a swap queue@len +
  ;
: empty_queue?  ( queue -- flag )
  \ Is a queue empty?
  queue@len 0=
  ;
: full_queue?  ( queue -- flag )
  \ Is a queue full?
  dup queue@len swap queue@max =
  ;
: queue!len  ( n queue -- )
  \ Set the length of a queue.
  queue>len !
  ;
: queue_off  ( queue -- )
  \ Empty a queue.
  \ XXX TODO better name
  queue>len off
  ;
: resize_queue  ( queue n -- )
  \ Add n address units to the current length of a queue.
  over queue@len + swap queue>len !
  ;
: queue_count  ( queue -- a len )
  \ Address and length of a queue.
  dup queue@a swap queue@len
  ;
: smaller_queue  ( queue n -- )
  \ Reduce the queue by n address units.
  2dup negate resize_queue
  >r queue_count swap dup r> + swap rot move
  ;
: not_empty ( -- )
  empty_queue? abort" Empty queue"
  ;
: not_full  ( -- )
  full_queue? abort" Full queue"
  ;
: queue@  ( queue -- x )
  \ Fetch a cell from a queue.
  dup not_empty
  dup queue@a @ >r
  cell smaller_queue  r>
  ;
: queue!  ( x queue -- )
  \ Store a cell into a queue.
  dup not_full
  swap over queue> !
  cell resize_queue
  ;
: queue2@  ( queue -- x1 x2 )
  \ Fetch two cells from a queue.
  dup not_empty
  dup queue@a 2@ 2>r
  2 cells smaller_queue  2r>
  ;
: queue2!  ( x1 x2 queue -- )
  \ Store two cells into a queue.
  dup >r not_full
  r@ queue> 2!
  r> 2 cells resize_queue
  ;

: .queue  ( queue -- )
  ." <" dup queue@len cell / 0 .r ." > "
  queue_count bounds ?do  i @ .  cell +loop
  ;
: dump_queue  ( queue -- )
  queue_count dump
  ;

\ ==============================================================
\ Usage examples

8 cells queue zx

100 zx queue!
200 zx queue!
300 zx queue!

false [if]

zx queue@len . cr

1000. zx queue2!

zx queue2@ d. cr
zx queue@ . cr
zx queue@ . cr
zx queue@ . cr

[then]

\ ==============================================================
\ Change log

\ 2014-11-22: Written.
\
\ 2017-08-17: Update change log layout. Update section rulers.
