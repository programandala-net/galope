\ galope/lodge-resize.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge.fs

: (lodge-resize) ( u a -- +n )
  lodge ! /lodge @  swap /lodge +! ;
  \ u  = additional address units already allocated in the lodge
  \ a  = new address of the lodge
  \ +n = offset to the new free space (it's the same than the
  \      previous length of the lodge)

: lodge-resize ( u -- +n ior )
  lodge @ swap resize >r (lodge-resize) r> ;

  \ doc{
  \
  \ lodge-resize ( u -- +n ior )
  \
  \ Resize the `lodge` to _u_ address units.  If the operation
  \ succeeds, _+n_ is the offset to the additional free space
  \ and _ior_ is zero.  If the operation fails, the value of
  \ _+n_ is unimportant and _ior_ in the corresponding I/O
  \ result code.
  \
  \ See: `lodge-allocate`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>.
