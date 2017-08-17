\ galope/str-greater.fs
\ str>

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ 2014-03-12: Added.

: str>  ( ca1 len1 ca2 len2 -- wf )
  \ Is the ca1 len1 lexicographically larger than ca2 len2?
  compare 0>
  ;

