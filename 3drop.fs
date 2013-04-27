\ galope/3drop.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-04 Added.

\ Taken from ToolBelt 2002 by Wil Baden.

: 3drop  ( x1 x2 x3 -- )
  \  Drop the top three elements from the stack.
  2drop drop
  ;
