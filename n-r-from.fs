\ galope/n-r-from.fs
\ nr>

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-08-10 Written after the Forth-2012 standard.

[undefined] nr> [if]

: nr>  ( -- i×n +n -- ) ( R: j×n +n -- )
  r> r> { a n }  \ save n and the return address
  n  begin  dup  while  r> swap 1-  repeat  drop n
  a >r  \ restore the return address
  ;

[then]
