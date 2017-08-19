\ galope/char-to-ruler.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017.

\ ==============================================================

require ./sb.fs

: char>ruler  ( c len -- ca len )
  dup sb_allocate swap 2dup 2>r  rot fill  2r>  ;

  \ doc{
  \
  \ char>ruler  ( c len -- ca len )
  \
  \ Return a string _ca len_ of _len_ characters _c_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-07: Added.
\
\ 2016-06-28: Update the file header and the source style. Rename
\ the file and the word.
\
\ 2017-08-19: Update change log layout. Document.
