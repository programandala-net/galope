\ galope/possibly.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-18 Added.

\ Taken from ToolBelt 2002 by Wil Baden.

: possibly  ( "name" -- )
  \  Execute 'name' if it exists; otherwise, do nothing.
  bl word find  ?dup and if  execute  then
  ;
