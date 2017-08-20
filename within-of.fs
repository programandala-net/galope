\ galope/within-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

: (within-of) ( x1 x2 x3 -- x1 x1 | x1 x1' )
  2>r dup dup 2r> within 0= if invert then ;

: within-of ( compilation: -- of-sys ) ( run-time: x1 x2 x3 -- | x1 )
  postpone (within-of) postpone of ; immediate compile-only

\ ==============================================================
\ Change log

\ 2014-02-14 Written after 'between-of'.
\
\ 2017-08-17: Update change log layout and source style.
