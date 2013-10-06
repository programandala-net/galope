\ galope/slash-string.fs
\ Left justify a string.

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-08-16 Written.

: /spaces  ( a len u -- a' u )
  \ Left justify a string
  \ by adding spaces to its right until its length is u.
  \ If len=u, the string does not change.
  \ If len>u, the string is truncated at the right.
  >r pad r@  2dup blank  s+ drop r> 
  ;
