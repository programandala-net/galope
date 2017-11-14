\ galope/between-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./between.fs

: (between-of) ( x1 x2 x3 -- x1 x1 | x1 x1' )
  2>r dup dup 2r> between 0= if invert then ;

: between-of \ Compilation: ( -- of-sys )
             \ Run-time:    ( x1 x2 x3 -- | x1 )
  postpone (between-of) postpone of ; immediate compile-only

  \ doc{
  \
  \ between-of \ Compilation: ( -- of-sys )
  \            \ Run-time:    ( x1 x2 x3 -- | x1 )
  \
  \ A variant of ``of`` that compares using `between`.
  \
  \ Usage example:
  \
  \ ----

  \ : test ( x -- )
  \   case
  \     1           of ." one"                  endof
  \     2 5 between-of ." between two and five" endof
  \     6           of ." six"                  endof
  \   endcase ;

  \ ----
  \
  \ See: `within-of`, `any-of`. `or-of`, `less-of`, `greater-of`,
  \ `default-of`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-02-10: Written.
\
\ 2014-02-12: Renamed from "range-of" to "between-of", in order to
\ write also "within-of", so both definitions are clear.
\
\ 2014-03-13: Usage example.
\
\ 2017-08-20: Update change log layout and source style.
\
\ 2017-10-24: Improve documentation.
\
\ 2017-11-14: Update documentation.
