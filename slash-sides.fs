\ galope/slash-sides.fs
\ /sides

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ Credit: This word was inspired by Wil Baden's `hunt` (Charscan
\ library, 2003-02-17, public domain).

\ ==============================================================

require ./sides.fs  \ 'sides'

: /sides  { ca1 len1 ca2 len2 -- ca1 len1' ca3 len3 f }
  ca1 len1 ca2 len2 search dup >r
  if    ca1 len1 len2 sides
  else  over 0  \ fake right side
  then  r>  ;
  \ Search a string _ca1 len1_ for the first occurence of a substring
  \ _ca2 len2_ and return the substring _ca1 len1'_ at its left and
  \ _ca3 len3_ at its right.  If _ca2 len2_ is found, _f_ is true.
  \ Any returned substring can be empty, even if _ca2 len2_ is found,
  \ depending on its position in _ca1 len1_.

\ ==============================================================
\ History

\ 2013-07-11: Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo.html)
\
\ 2013-11-06: Changed the stack notation of flag.
\
\ 2016-07-29: Update source layout and file header.
