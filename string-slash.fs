\ galope/string-slash.fs
\ string/

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-10: Added.
\ 2014-11-02: Change: stack comments. 

\ Taken from Charscan by Wil Baden (2002-2003).

: string/  ( ca1 len1 len2 -- ca2 len2 )
  \ Return the len2 ending characters of a string.
  >r + r@ - r>
  ;

