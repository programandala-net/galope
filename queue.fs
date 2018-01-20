\ galope/queue.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017, 2018.

\ ==============================================================

0
  field: queue>out  \ output address
  field: queue>used \ used space, in address units
  field: queue>size \ maximum size, in address units
constant /queue

  \ doc{
  \
  \ queue>out ( a1 -- a2 )
  \
  \ Convert queue header _a1_ to its output address _a2_, which
  \ is the address of the next element to be fetched from the
  \ queue.
  \
  \ See: `queue>in`, `queue>used`, `queue>size`,
  \ `allocate-queue`, `allot-queue`.
  \
  \ }doc

  \ doc{
  \
  \ queue>used ( a1 -- a2 )
  \
  \ Convert queue header _a1_ to the address _a2_ containing the
  \ length of the queue, in address units.
  \
  \ See: `queue>size`, `queue>in`, `queue>out`,
  \ `allocate-queue`, `allot-queue`.
  \
  \ }doc

  \ doc{
  \
  \ queue>size ( a1 -- a2 )
  \
  \ Convert queue header _a1_ to the address _a2_ containing the
  \ maximum length of the queue, in address units.
  \
  \ See: `queue>used`, `queue>in`, `queue>out`,
  \ `allocate-queue`, `allot-queue`.
  \
  \ }doc

  \ doc{
  \
  \ /queue ( -- n )
  \
  \ Return the size of a queue header structure, in _n_ address
  \ units.
  \
  \ See: `queue,`, `allocate-queue`, `allot-queue`.
  \
  \ }doc

: queue, ( n a -- ) , 0 , , ;

  \ doc{
  \
  \ queue, ( n a -- )
  \
  \ Compile the data structure of a queue with output address
  \ _a_ and maximum size _n_ address units.
  \
  \ ``queue,`` is a factor of ` `allocate-queue`, `allot-queue`.
  \
  \ See: `/queue`.
  \
  \ }doc

: allocate-queue ( n "name" -- )
  create dup allocate throw queue, ;

  \ doc{
  \
  \ Create a queue _name_ in the heap with a maximum size of _n_
  \ address units.
  \
  \ When _name_ is later executed, it will return the address of
  \ the queue's header.
  \
  \ See: `allot-queue`, `queue,`, `queue>in`, `queue>out`,
  \ `queue>used`, `queue>size`.  `.queue`, `dump-quoue`.
  \
  \ }doc

: allot-queue ( n "name" -- )
  create dup here /queue + queue, allot ;
  \ Create a named queue _name_ in data space with a maximum
  \ size of _n_ address units.

  \ doc{
  \
  \ Create a queue _name_ in data space with a maximum size of
  \ _n_ address units.
  \
  \ When _name_ is later executed, it will return the address of
  \ the queue's header.
  \
  \ See: `allocate-queue`, `queue,`, `queue>in`, `queue>out`,
  \ `queue>used`, `queue>size`, `.queue`, `dump-quoue`.
  \
  \ }doc

: queue>in ( a1 -- a2 ) dup queue>out @ swap queue>used @ + ;

  \ doc{
  \
  \ queue>in ( a1 -- a2 )
  \
  \ Convert queue header _a1_ to its input address _a2_, which
  \ is the address the next element will be stored at.
  \
  \ See: `queue>out`, `queue>used`, `queue>size`,
  \ `allocate-queue`, `allot-queue`.
  \
  \ }doc

: empty-queue? ( a -- flag ) queue>used @ 0= ;

  \ doc{
  \
  \ empty-queue? ( a -- flag )
  \
  \ Is queue _a_ empty?
  \
  \ See: `full-queue?`, `?empty-queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: full-queue? ( a -- flag )
  dup queue>used @ swap queue>size @ >= ;

  \ doc{
  \
  \ full-queue? ( a -- flag )
  \
  \ Is queue _a_ full?
  \
  \ See: `empty-queue?`, `?full-queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: count-queue ( a1 -- a2 len )
  dup queue>out @ swap queue>used @ ;

  \ doc{
  \
  \ count-queue ( a1 -- a2 len )
  \
  \ Convert queue _a1_ to its output address _a2_ and its
  \ current length _len_ in address units.
  \
  \ See: `resize-queue`, `allocate-queue`, `allot-queue`.
  \
  \ }doc

: resize-queue ( a n -- ) swap queue>used +! ;

  \ doc{
  \
  \ resize-queue ( a +n|-n -- )
  \
  \ Update the used space of queue _a_ after _+n_ address units
  \ has been used, or _+n_ address units have been freed.
  \
  \ See: `queue>used`, `adjust-queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: adjust-queue ( a -n -- )
  over queue>out @ swap - swap count-queue move ;

  \ doc{
  \
  \ adjust-queue ( a -n -- )
  \
  \ Adjust queue _a_ by _-n_ address units.  This operation
  \ moves the contents of the queue towards its output address,
  \ after something has been fetched from the queue.
  \
  \ See: `resize-queue`, `count-queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: ?empty-queue ( a -- ) empty-queue? abort" Empty queue" ;

  \ doc{
  \
  \ ?empty-queue ( a -- )
  \
  \ If queue _a_ is empty, abort.
  \
  \ See: `empty-queue?`, `?full-queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: ?full-queue ( a -- ) full-queue? abort" Full queue" ;

  \ doc{
  \
  \ ?full-queue ( a -- )
  \
  \ If queue _a_ is full, abort.
  \
  \ See: `full-queue?`, `?empty-queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: c@queue ( a -- c )
  dup ?empty-queue
  dup queue>out @ c@
  swap [ 1 chars negate ] literal 2dup resize-queue
                                       adjust-queue ;
  \ Fetch a character _c_ from a queue _a_.

  \ doc{
  \
  \ c@queue ( a -- c )
  \
  \ Fetch character _c_ from queue _a_
  \
  \ See: `c!queue`, `@queue`, `2@queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: c!queue ( c a -- )
  dup ?full-queue
  swap over queue>in c!
  [ 1 chars ] literal resize-queue ;

  \ doc{
  \
  \ c!queue ( x a -- )
  \
  \ Store character _c_ into queue _a_.
  \
  \ See: `c@queue`, `!queue`, `2!queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: @queue ( a -- x )
  dup ?empty-queue
  dup queue>out @ @
  swap [ cell negate ] literal 2dup resize-queue adjust-queue ;

  \ doc{
  \
  \ @queue ( a -- x )
  \
  \ Fetch cell _x_ from queue _a_
  \
  \ See: `!queue`, `2@queue`, `c@queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: !queue ( x a -- )
  dup ?full-queue
  swap over queue>in !
  cell resize-queue ;

  \ doc{
  \
  \ !queue ( x a -- )
  \
  \ Store cell _x_ into queue _a_.
  \
  \ See: `@queue`, `2!queue`, `c!queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: 2@queue ( a -- x1 x2 )
  dup ?empty-queue
  dup queue>out @ 2@
  rot [ 2 cells negate ] literal 2dup resize-queue
                                      adjust-queue ;

  \ doc{
  \
  \ 2@queue ( a -- x1 x2 )
  \
  \ Fetch cell pair _x1 x2_ from queue _a_
  \
  \ See: `2!queue`, `@queue`, `c@queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: 2!queue ( x1 x2 a -- )
  dup >r ?full-queue
      r@ queue>in 2!
      r> [ 2 cells ] literal resize-queue ;

  \ doc{
  \
  \ 2!queue ( x1 x2 a -- )
  \
  \ Store cell pair _x1 x2_ into queue _a_.
  \
  \ See: `2@queue`, `!queue`, `c!queue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: .queue ( a -- )
  ." <" dup queue>used @ cell / 0 .r ." > "
  count-queue bounds ?do i @ . cell +loop ;

  \ doc{
  \
  \ .queue ( a -- )
  \
  \ Display the contents of queue _a_, after the format used by
  \ ``.s``. The first item listed is the oldest one, and
  \ therefore it's also the first one to be fetched.
  \
  \ See: `dump-queue`, `count-quoue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: dump-queue ( a -- ) count-queue dump ;

  \ doc{
  \
  \ dump-quoue ( a -- )
  \
  \ Dump the the contents of queue _a_.
  \
  \ See: `.queue`, `count-quoue`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

: clear-queue ( a -- ) queue>used off ;

  \ doc{
  \
  \ clear-queue ( a -- )
  \
  \ Clear queue _a_.
  \
  \ See: `empty-queue?`, `queue>used`, `allocate-queue`,
  \ `allot-queue`.
  \
  \ }doc

\ ==============================================================
\ Usage examples

false [if]

warnings off

8 cells allot-queue zx

cr
zx .queue cr
100 zx !queue
zx .queue cr
200 zx !queue
zx .queue cr
300 zx !queue
zx .queue cr
1000. zx 2!queue
zx .queue cr

zx queue>used @ . .( used) cr

zx .queue cr

zx @queue . .( shoud be 100) cr
zx .queue cr
zx @queue . .( shoud be 200) cr
zx .queue cr
zx @queue . .( shoud be 300) cr
zx .queue cr
zx 2@queue d. .( should be 1000) cr
zx .queue cr

[then]

\ ==============================================================
\ Change log

\ 2014-11-22: Written.
\
\ 2017-08-17: Update change log layout. Update section rulers.
\
\ 2018-01-20: Update source style. Fix some stack comments.
\ Improve names. Simplify the interface. Convert `queue` to
\ `allocate-queue` and write `allot-queue`. Factor `queue,`. Use
\ a data structure for the queue header. Add `c!queue` and
\ `c@queue`. Document.
