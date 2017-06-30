\ galope/question-free.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ History

\ 2013-08-30 Extracted from "La isla del Coco", by the same author;
\ modifed to return the ior instead doing 'throw', after the
\ homonymous word provided by Forth Foundation Library in its config
\ file.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

[undefined] ?free  [if]
: ?free  ( a -- ior )
  ?dup if  free  else  0  then
  ;
[then]
