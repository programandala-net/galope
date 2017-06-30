\ galope/spaces-slash.fs
\ Right justify a string.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013,2014 Marcos Cruz (programandala.net)

\ 2013-08-16: Written.
\ 2014-11-16: Comments are updated.

require ./string-slash.fs

: spaces/  ( ca len1 len2 -- ca' len2 )
  \ Right justify a string
  \ by adding spaces to its left until its length is len2.
  \ If len1=len2, the string does not change.
  \ If len1>len2, the string is truncated at the left.
  >r pad r@  2dup blank  2swap s+ r> string/
  ;

