\ galope/any-of.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

: (any-of) ( x#0 x#1 .. x#n n -- x#0 x#0 | x#0 x#0' )
  dup 1+ roll false {: x#0 match :}
  0 ?do x#0 = match or to match loop
  match dup dup 0= if invert then ;
  \ Compare _n_ values _x#1 .. x#n_ with _x#0_.  If _x#0_ is
  \ equal to any of _x#1 .. x#n_, leave _x#0 x#0_ on the stack;
  \ otherwise leave _x#0 x#0'_, being _x#0_ not equal to
  \ _x#0'_.

: any-of \ Compilation: ( -- of-sys )
         \ Run-time:    ( x#0 x#1 .. x#n n -- | x#0 )
  postpone (any-of) postpone of ; immediate compile-only

  \ doc{
  \
  \ any-of \ Compilation: ( -- of-sys )
  \        \ Run-time:    ( x#0 x#1 .. x#n n -- | x#0 )

  \ A variant of ``of`` that compares _x#0_ with all _n_ values
  \ _x#1 .. x#n_.
  \
  \ Usage example:
  \
  \ ----

  \ : test ( x -- )
  \   case
  \     1           of ." one"                endof
  \     2 3 4 3 any-of ." two, three or four" endof
  \     5           of ." five"               endof
  \   endcase ;

  \ ----
  \
  \ See: `or-of`, `within-of`, `between-of`, `less-of`,
  \ `greater-of`, `default-of`, `any?`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-14: Start.
