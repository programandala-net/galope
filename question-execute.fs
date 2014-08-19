\ galope/question-execute.fs
\ ?execute

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ 2014-02-17 Added. It was noted in the to-do list.

: ?execute  ( xt | 0 -- )
  ?dup if  execute  then
  ;

