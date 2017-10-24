\ galope/greater-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./nup.fs

: (greater-of) ( x1 x2 -- x1 x1 | x1 x1' )
  nup nup <= if invert then ;

: greater-of \ Compilation: ( -- of-sys )
             \ Run-time:    ( x1 x2 -- | x1 )
  postpone (greater-of) postpone of ; immediate compile-only

  \ doc{
  \
  \ greater-of \ Compilation: ( -- of-sys )
  \            \ Run-time:    ( x1 x2 -- | x1 )
  \
  \ A variant of ``of`` that compares using ``>``.
  \
  \ Usage example:
  \
  \ ----

  \ : test ( x -- )
  \   case
  \     10      of ." ten!"         endof
  \     15 greater-of  ." greater than 15"  endof
  \     ." less than 10 or 11..15"
  \   endcase ;

  \ ----
  \
  \ See: `less-of`, `between-of`, `within-of`, `or-of`,
  \ `default-of`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-02-12: Written.
\
\ 2014-02-15: '>r dup dup r>' changed to 'nup nup'.
\
\ 2014-03-12: Usage example.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-10-24: Improve documentation.
