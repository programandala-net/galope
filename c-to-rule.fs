\ galope/c-to-rule.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-02-19: Written.
\ 2015-10-15: Renamed filename.

: c>rule  ( c len -- ca len )
  \ Create a string with a repeated ASCII char.
  dup allocate throw  swap 2dup 2>r  rot fill  2r>
  ;
