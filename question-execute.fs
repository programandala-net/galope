\ galope/question-execute.fs
\ `?execute`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ ==============================================================

: ?execute  ( xt | 0 -- )
  ?dup if  execute  then  ;

\ ==============================================================
\ History

\ 2014-02-17: Add to the library.
\
\ 2016-07-11: Update source layout and file header.
