\ galope/string-slash.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-12-10 Added.

\ Taken from Charscan by Wil Baden (2002-2003).

: string/  ( a u n -- a3 u3 )
  \ Return the n ending characters of a string.
  >r + r@ - r>
  ;

