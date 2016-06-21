\ galope/slash-spaces.fs
\ Left justify a string.

\ This file is part of Galope

\ Copyright (C) 2013,2014 Marcos Cruz (programandala.net)

\ 2013-08-16: Written.
\ 2014-11-16: Comments are updated.

: /spaces  ( ca len1 len2 -- ca' len2 )
  \ Left justify a string
  \ by adding spaces to its right until its length is len2.
  \ If len1=len2, the string does not change.
  \ If len1>len2, the string is truncated at the right.
  >r pad r@  2dup blank  s+ drop r>
  ;
