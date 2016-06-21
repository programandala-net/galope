\ galope/two-roll.fs
\ Double number roll

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History

\ 2012-04-30 First version.

[undefined] 2roll [if]
: 2roll ( d0 d1 ... dn n -- d1 ... dn d0 )
  2 * dup >r roll r> 1+ roll swap
  ;
[then]
