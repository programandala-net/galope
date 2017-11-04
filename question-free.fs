\ galope/question-free.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: ?free ( a|0 -- ior ) dup if free then ;

  \ doc{
  \
  \ ?free ( a|0 -- ior )
  \
  \ If TOS is zero, _ior_ is zero.
  \
  \ Otherwise return the contiguous region of data space indicated by
  \ _a_ to the system for later allocation. _a_ shall indicate a
  \ region of data space that was previously obtained by ``allocate``
  \ or ``resize``. If the operation succeeds, _ior_ is zero; if the
  \ operation fails, _ior_ is the implementation-defined I/O result
  \ code.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-08-30 Extracted from "La isla del Coco"
\ (http://programandala.net/es.programa.la_isla_del_coco.html);
\ modifed to return the ior instead doing 'throw', after the
\ homonymous word provided by Forth Foundation Library in its config
\ file.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style. Fix stack comment.
\
\ 2017-11-04: Simplify the code. Improve documentation.
