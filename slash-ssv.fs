\ galope/slash-ssv.fs
\ /ssv

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ ==============================================================

require ./slash-sides.fs  \ '/sides'

: /ssv  ( ca len -- ca#1 len#1 ... ca#u len#u u )

  \ Divide a space separated values string.

  \ Any group of spaces is regarded as a field delimiter.  For a
  \ strict version of this word, that regards every single space as a
  \ delimiter, use `/ssv-strict`.

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

\ ==============================================================
\ Change log

\ 2014-12-05: Added. Taken from Fendo's <fendo.data.fs>
\ (http://programandala.net/en.program.fendo.html) and
\ fixed.
\
\ 2017-08-17: Update change log layout.
