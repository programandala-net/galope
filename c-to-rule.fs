\ galope/c-to-rule.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ ==============================================================

: c>rule ( c len -- ca len )
  dup allocate throw swap 2dup 2>r rot fill 2r> ;
  \ Create a string with a repeated ASCII char.

\ ==============================================================
\ Change log

\ 2014-02-19: Written.
\
\ 2015-10-15: Renamed filename.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
