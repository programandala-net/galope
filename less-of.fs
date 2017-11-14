\ galope/less-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./nup.fs

: (less-of) ( x1 x2 -- x1 x1 | x1 x1' )
  nup nup >= if invert then ;

: less-of \ Compilation: ( -- of-sys )
          \ Run-time:    ( x1 x2 -- | x1 )
  postpone (less-of) postpone of ; immediate compile-only

  \ doc{
  \
  \ less-of \ Compilation: ( -- of-sys )
  \         \ Run-time:    ( x1 x2 -- | x1 )
  \
  \ A variant of ``of`` that compares using ``<``.
  \
  \ Usage example:
  \
  \ ----

  \ : test ( x -- )
  \   case
  \     10      of ." ten!"         endof
  \     15 less-of ." less than 15" endof
  \     ." greater than 14"
  \   endcase ;

  \ ----
  \
  \ See: `greater-of`, `between-of`, `within-of`, `or-of`, `any-of`,
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
\
\ 2017-11-14: Update documentation.
