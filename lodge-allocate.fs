\ galope/lodge-allocate.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge.fs
require ./lodge-resize.fs

: lodge-allocate ( n1 -- +n2 ior )
  dup /lodge @ + lodge-resize ;

  \ doc{
  \
  \ lodge-allocate ( n1 -- +n2 ior )
  \
  \ Allocate _n1_ additional address units in the `lodge`.  If
  \ the operation succeeds, _+n2_ is the offset to the
  \ additional free space and _ior_ is zero.  If the operation
  \ fails, the value of _+n2_ is unimportant and _ior_ is the
  \ corresponding I/O result code.
  \
  \ See: `lodge-resize`, `lodge-allot`, `lodge-here`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>.
