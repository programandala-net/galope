\ galope/slash-ssv-strict.fs
\ /ssv-strict

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014,2015 Marcos Cruz (programandala.net)

\ History
\
\ 2015-12-15: Added to the library. This was the old version of
\ `/ssv`.

require ./slash-sides.fs  \ '/sides'

: /ssv-strict  ( ca len -- ca#1 len#1 ... ca#u len#u u )

  \ Divide a space separated values string.
  \
  \ Every space is regarded as a field delimiter, so
  \ double spaces cause empty strings. For a non-strict
  \ versin of this word, use `/ssv`.
  \
  \ ca len = string with space separated values
  \ ca#1 len#1 ... ca#u len#u = one or more strings
  \ u = number of strings returned

  \ XXX TODO make it simpler: use 'execute-parsing' instead.

  depth >r
  begin  s"  " /sides 0=  until  2drop
  depth r> 2 - - 2/
  ;
