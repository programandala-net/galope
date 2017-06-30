\ galope/four-drop.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-01-04 Added.

: 4drop  ( x1 x2 x3 x4 -- )
  \  Drop the top four elements from the stack.
  2drop 2drop
  ;
