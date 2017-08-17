\ galope/benched.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2016 Marcos Cruz (programandala.net)

\ ==============================================================
\ Credits

\ Code adapted from Solo Forth.  The Solo Forth version was adapted
\ from Forth Dimensions (volume 17, number 4 page 11, 1995-11).

\ ==============================================================

2variable bench0

: bench{  ( -- )  utime bench0 2!  ;
  \ start timing

: }bench  ( -- d )  utime bench0 2@ d-  ;
  \ stop timing

: bench.  ( d -- )  d. ." ms"  ;
  \ print the result _d_

: }bench.  ( -- )  }bench bench.  ;
  \ stop timing and print the result

: benched  ( xt n -- d )
  bench{ 0 do  dup execute  loop  }bench rot drop  ;

: benched.  ( xt n -- )
  bench{ 0 do  dup execute  loop  }bench. drop  ;

\ ==============================================================
\ Change log

\ 2016-03-15: Added.
\
\ 2017-08-17: Update change log layout.
