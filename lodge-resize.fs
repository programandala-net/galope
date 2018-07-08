\ galope/lodge-resize.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./lodge.fs

: lodge-resize ( u -- ior )
  lodge @ over resize dup >r if   2drop
                             else lodge ! /lodge !
                             then r> ;

  \ doc{
  \
  \ lodge-resize ( u -- ior )
  \
  \ Resize the `lodge` to _u_ address units.  If the operation
  \ succeeds, `lodge` and `/lodge` are updated and _ior_ is zero.  If
  \ the operation fails, `lodge` and `/lodge` remain untouched and
  \ _ior_ in the corresponding I/O result code.
  \
  \ See: `lodge-allocate`, `lodge-allot`, `lodge-here`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-12: Extract from <lodge.fs>. Improve documentation.
\
\ 2018-06-23: Fix and rewrite `lodge-resize`. Remove its factor
\ `(lodge-resize)`.
