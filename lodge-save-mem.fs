\ galope/lodge-save-mem.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge.fs
require ./lodge-allocate.fs

: lodge-save-mem ( a len -- +n len )
  swap >r dup lodge-allocate throw swap over lodge+ over
       r> -rot move ;

  \ doc{
  \
  \ lodge-save-mem ( a len -- +n len )
  \
  \ Add a memory zone _a len_ to the `lodge`, increasing its
  \ size accordingly and returning its offset _+n_ and the
  \ length _len_ of the zone.
  \
  \ See: `lodge-,`, `lodge-2,`, `lodge-allocate`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>.
