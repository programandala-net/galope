\ galope/question-nip.fs
\ ?nip

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-12-31 Added.

: ?nip  ( false | x non-false -- f )
  \ Discard the second element on the stack if top of stack is not
  \ false. Leave the top of stack unchanged.
  dup if  nip  then
  ;

