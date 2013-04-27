\ galope/3dup.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-04 Added.

\ Taken from ToolBelt 2002 by Wil Baden.

require galope/third.fs

: 3dup  ( x1 x2 x3 -- x1 x2 x3 x1 x2 x3 )
  \  Copy top three elements on the stack onto top of stack.
  third third third
  ;
