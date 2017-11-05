\ galope/two-roll.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

: 2roll ( xd#0 xd#1 ... xd#u u -- xd#1 ... xd#u xd#0 )
  2 * dup >r roll r> 1+ roll swap ;

  \ doc{
  \
  \ 2roll ( xd#0 xd#1 ... xd#u u -- xd#1 ... xd#u xd#0 )
  \
  \ Remove _u_. Rotate _u+1_ double-cell items on the top of the
  \ stack.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-04-30 First version.
\
\ 2017-08-17: Update change log layout.
\
\ 2017-11-05: Improve stack comment and documentation. Remove
\ conditional compilation.
