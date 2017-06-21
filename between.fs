\ galope/between.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ This file is public domain.

\ History
\ 2012-05-05: First version.
\ 2014-06-20: Stack comment fixed.
\ 2017-06-21: Rewrite. `1+ within` doesn't work over the full range.

[undefined] between [if]

: between ( n low high -- f ) over - -rot - u< 0= ;

[then]

