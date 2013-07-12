\ galope/buffer-colon.fs

\ This file is part of Galope

\ Copyright (C) 2012,2013 Marcos Cruz (programandala.net)

\ History
\ 2012-05-19 Added. 'buffer:' is common use.
\ 2013-05-18 Conditional compilation, because 'buffer:' has been
\   included in the Forth-2012 Standard, and eventually will be
\   part of Gforth. Stack notation modifed.

\ Taken from ToolBelt 2002 by Wil Baden.

[undefined] buffer: [if]

: buffer:  ( u "name" -- ; -- a )
  create allot
  ;

[then]
