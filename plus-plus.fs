\ galope/plus-plus.fs
\ Increment the content of an address

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-05 First version.
\ 2012-05-07 File renamed.
\ 2012-09-14 Code reformated.

[undefined] ++ [if]
  : ++ ( a -- )
  1 swap +!
  ;
[then]
