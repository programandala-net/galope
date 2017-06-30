\ galope/slash-slash.fs
\ /slash

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014,2015 Marcos Cruz (programandala.net)

\ History
\
\ 2015-12-15: Added to the library.

require ./slash-sides.fs  \ '/sides'

: /slash  ( ca len -- ca#1 len#1 ... ca#u len#u u )

  \ Divide a slash separated values string.
  \
  \ ca len = string with slash separated values
  \ ca#1 len#1 ... ca#u len#u = one or more strings
  \ u = number of strings returned

  \ XXX TODO make it simpler: use 'execute-parsing' instead.

  depth >r
  begin  s" /" /sides 0=  until  2drop
  depth r> 2 - - 2/
  ;
