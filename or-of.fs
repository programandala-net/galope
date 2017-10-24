\ galope/or-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

: (or-of) ( x1 x2 x3 -- x1 x1 | x1 x1' )
  2>r dup dup dup r> = swap r> = or 0= if invert then ;

: or-of \ Compilation: ( -- of-sys )
        \ Run-time:    ( x1 x2 x3 -- | x1 )
  postpone (or-of) postpone of ; immediate compile-only

  \ doc{
  \
  \ or-of \ Compilation: ( -- of-sys )
  \       \ Run-time:    ( x1 x2 x3 -- | x1 )
  \
  \ A variant of ``of`` that compares with two values.
  \
  \ Usage example:
  \
  \ ----

  \ : test ( x -- )
  \   case
  \     1      of ." one"          endof
  \     2 3 or-of ." two or three" endof
  \     4      of ." four"         endof
  \   endcase ;

  \ ----
  \
  \ See: `within-of`, `between-of`, `less-of`, `greater-of`,
  \ `default-of`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-03-13: Written.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-10-24: Improve documentation.
