\ galope/string-slash.fs
\ string/

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-10: Added.
\ 2014-11-02: Change: stack comments.
\ 2016-04-03: Improved comment.

\ Credit
\ Taken from Charscan by Wil Baden (2002-2003).

: string/  ( ca1 len1 len2 -- ca2 len2 )
  >r + r@ - r>  ;
  \ Return the _len2_ ending characters of string _ca1 len1_.

