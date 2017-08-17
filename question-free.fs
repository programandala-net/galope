\ galope/question-free.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ ==============================================================

: ?free ( a|0 -- ior ) ?dup if free else 0 then ;

\ ==============================================================
\ Change log

\ 2013-08-30 Extracted from "La isla del Coco", by the same author;
\ modifed to return the ior instead doing 'throw', after the
\ homonymous word provided by Forth Foundation Library in its config
\ file.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style. Fix stack comment.
