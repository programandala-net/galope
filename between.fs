\ galope/between.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ This file is public domain.

\ History
\ 2012-05-05 First version.

[undefined] between [if]
  : between  ( n n1 n2 -- )
    1+ within
    ;
[then]

