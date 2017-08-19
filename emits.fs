\ galope/emits.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: emits ( c n -- ) 0 max 0 ?do dup emit loop drop ;

  \ doc{
  \
  \ emits ( c n -- )
  \
  \ If _n_ is greater than zero, display the character _c_ _n_ times.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-09-02 Written.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-08-19: Improve the code after the standard `spaces`: do nothing
\ if _n_ is negative. This is the code used also by Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).  Update sorce
\ style.  Document.
