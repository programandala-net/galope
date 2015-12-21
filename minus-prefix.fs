\ galope/minus-prefix.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-05-18: Added. First version.
\ 2015-12-16: Second, simpler version.

require ./gforth-question.fs

gforth? 0= [if]
  : string-prefix?  ( ca1 len1 ca2 len2 -- f )
    tuck 2>r min 2r> str=
    ;
[then]

false [if] \ XXX OLD -- first version

: -prefix  ( ca1 len1 ca2 len2 -- ca1' len1' )
  dup >r 2over 2swap string-prefix?
  if  swap r@ + swap r> -  else  rdrop  then  ;
  \ Remove a prefix _ca2 len2_ from a string _ca1 len1_.

[then]

: -prefix  ( ca1 len1 ca2 len2 -- ca1' len1' )
  dup >r 2over 2swap string-prefix? r> and /string  ;
  \ Remove a prefix _ca2 len2_ from a string _ca1 len1_.
