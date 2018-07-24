\ galope/two-pick.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

: 2pick ( xd[u]..xd[0] u -- xd[u] )
  2* dup 1+ pick swap 2 + pick swap ;

  \ doc{
  \
  \ 2pick ( xd[u]..xd[0] u -- xd[u] )
  \
  \ Remove _u_. Copy _xd[u]_ to the top of the stack.
  \
  \ See: `2choose`, `2drops`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-24: Factor from `2choose`.
