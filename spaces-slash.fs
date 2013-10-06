\ galope/string-slash.fs
\ Right justify a string.

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-08-16 Written.

require ./string-slash.fs

: spaces/  ( a len u -- a' u )
  \ Right justify a string
  \ by adding spaces to its left until its length is u.
  \ If len=u, the string does not change.
  \ If len>u, the string is truncated at the left.
  >r pad r@  2dup blank  2swap s+ r> string/
  ;

