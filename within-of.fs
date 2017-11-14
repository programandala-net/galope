\ galope/within-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

: (within-of) ( x1 x2 x3 -- x1 x1 | x1 x1' )
  2>r dup dup 2r> within 0= if invert then ;

: within-of \ Compilation: ( -- of-sys )
            \ Run-time:    ( x1 x2 x3 -- | x1 )
  postpone (within-of) postpone of ; immediate compile-only

  \ doc{
  \
  \ within-of \ Compilation: ( -- of-sys )
  \           \ Run-time:    ( x1 x2 x3 -- | x1 )
  \
  \ A variant of ``of`` that compares using `within`.
  \
  \ Usage example:
  \
  \ ----

  \ : test ( x -- )
  \   case
  \     1          of ." one"                 endof
  \     2 5 within-of ." within two and five" endof
  \     5          of ." five"                endof
  \   endcase ;

  \ ----
  \
  \ See: `between-of`, `any-of`, `or-of`, `less-of`, `greater-of`,
  \ `default-of`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-02-14 Written after 'between-of'.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-10-24: Improve documentation.
\
\ 2017-11-14: Update documentation.
