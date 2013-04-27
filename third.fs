\ galope/third.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-04 Added.

\ Taken from ToolBelt 2002 by Wil Baden.

: third  ( x1 x2 x3 -- x1 x2 x3 x1 )
  \ Copy third element on the stack onto top of stack.
  2 pick
  ;
