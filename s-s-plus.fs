\ galope/s-s-plus.fs
\ `ss+`
\ Stringer strings concatenator.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ Description: An operator to concatenate strings and return the
\ result in the stringer (a circular string buffer).

\ ==============================================================

require ./stringer.fs
require ./both-lengths.fs
require ./smove.fs

: ss+  ( ca1 len1 ca2 len2 -- ca3 len3 )
  both-lengths + >r  ( ca1 len1 ca2 len2 ) ( R: len3 )
  r@ allocate-ss >r  ( R: len3 ca3 )
  2 pick r@ +  ( ca1 len1 ca2 len2 ca3+len1 )  smove  ( ca1 len1 )
  r@ smove  r> r>  ;
  \ Concatenate strings _ca1 len1_ and _ca2 len2_ (adding string _ca2
  \ len2_ at the end of string _ca len1_), returning the result _ca3
  \ len3_ in the stringer (a circular string buffer).

\ ==============================================================
\ History

\ 2016-07-19: Move from <stringer.fs>.
\ 2016-07-20: Improve comment.
\ 2016-07-22: Improve comment.
