\ galope/string-slash.fs
\ string/

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Taken from Wil Baden's Charscan (2002-2003).

\ ==============================================================

: string/ ( ca1 len1 len2 -- ca2 len2 )
  >r + r@ - r> ;
  \ Return the _len2_ ending characters of string _ca1 len1_.

\ ==============================================================
\ Change log

\ 2012-12-10: Added.
\
\ 2014-11-02: Change: stack comments.
\
\ 2016-04-03: Improved comment.
\
\ 2017-08-17: Update change log layout. Update header and source
\ style.
