\ galope/slash-ssv.fs
\ /ssv

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ 2014-12-05: Added. Taken from Fendo's <fendo.data.fs>
\ (http://programandala.net/en.program.fendo.html) and
\ fixed.

require ./slash-sides.fs  \ '/sides'

false [if]
  \ XXX OLD first version, buggy
  : /ssv  ( ca len -- ca#1 len#1 ... ca#u len#u u )
    \ Divide a space separated values string.
    \ ca len = string with space separated values
    \ ca#1 len#1 ... ca#u len#u = one or more strings
    \ u = number of strings returned
    \ XXX TODO make it simpler: use 'execute-parsing' instead.
    \ XXX FIXME double spaces cause empty strings
    depth >r
    begin  s"  " /sides 0=  until  2drop
    depth r> 2 - - 2/
    ;
[then]

: /ssv  ( ca len -- ca#1 len#1 ... ca#u len#u u )
  \ Divide a space separated values string.
  \ ca len = string with space separated values
  \ ca#1 len#1 ... ca#u len#u = one or more strings
  \ u = number of strings returned
  \ XXX TODO make it simpler: use 'execute-parsing' instead.
  depth >r
  begin
    s"  " /sides >r
    2swap dup 0= if  2drop  else  2swap  then
    r> 0=
  until  2drop depth r> 2 - - 2/
  ;
