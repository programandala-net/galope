\ galope/minus-minus.fs
\ Decrement the content of an address

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012,2016

\ Licence
\
\ You may do whatever you want with this work, so long as you
\ retain the copyright/authorship/acknowledgment/credit
\ notice(s) and this license in all redistributed copies and
\ derived works.  There is no warranty.

\ History
\
\ 2012-05-05: First version.
\ 2012-05-07: File renamed.
\ 2012-09-14: Code reformated.
\ 2016-01-16: Updated header and layout.

[undefined] -- [if]
  : -- ( a -- )
    -1 swap +!  ;
[then]

