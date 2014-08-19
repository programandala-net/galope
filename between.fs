\ galope/between.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ This file is public domain.

\ History
\ 2012-05-05: First version.
\ 2014-06-20: Stack comment fixed.

[undefined] between [if]
  : between  ( n n1 n2 -- wf )
    1+ within
    ;
[then]

