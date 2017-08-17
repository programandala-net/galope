\ galope/two-roll.fs
\ Double number roll

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ ==============================================================

[undefined] 2roll [if]
: 2roll ( d0 d1 ... dn n -- d1 ... dn d0 )
  2 * dup >r roll r> 1+ roll swap ;
[then]

\ ==============================================================
\ Change log

\ 2012-04-30 First version.
\
\ 2017-08-17: Update change log layout.

