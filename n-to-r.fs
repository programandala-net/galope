\ galope/n-to-r.fs
\ n>r

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-08-10 Written after the Forth-2012 standard.

[undefined] n>r [if]

: n>r  ( i×n +n -- ) ( R: -- j×n +n )
  r> { n a }  \ save n and the return address
  n  begin  dup  while  swap >r 1-  repeat  drop n >r
  a >r  \ restore the return address
  ;

[then]
