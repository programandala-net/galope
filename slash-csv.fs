\ galope/slash-csv.fs
\ /csv

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-11-11: Added. Taken from Fendo's <fendo_data.fs>
\ (http://programandala.net/en.program.fendo.html)
\ 2014-11-29: Change: Comments.

require ./slash-sides.fs  \ '/sides'

: /csv  ( ca len -- ca#1 len#1 ... ca#u len#u u )
  \ Divide a comma separated values string.
  \ ca len = string with comma separated values
  \ ca#1 len#1 ... ca#u len#u = one or more strings
  \ u = number of strings 
  depth >r
  begin  s" ," /sides 0=  until  2drop
  depth r> 2 - - 2/
  ;

false [if]  \ xxx todo
: /csv  ( ca len -- ca#1 len#1 ... ca#u len#u u )
  \ Divide a comma separated values string;
  \ remove their trailing and leading spaces
  \ and remove the empty values.
  \ ca len = string with comma separated values
  \ ca#1 len#1 ... ca#u len#u = one or more strings
  \ u = number of strings
  (/csv) depth 1- >r 0 ?do
    trim dup 0= if  2drop  then
  loop  r> depth - 2/
  ;
[then]
