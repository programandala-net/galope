\ galope/fourth.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-04 Added.

\ Taken from ToolBelt 2002 by Wil Baden.

: fourth  ( x1 x2 x3 x4 -- x1 x2 x3 x4 x1 )
  \ Copy fourth element on the stack onto top of stack.
  3 pick
  ;

