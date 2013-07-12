\ galope/char-to-buffered-string.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-07 Added.

require ./sb.fs

: c>bs  ( c u -- a u )
  \ Make a string from a character and a length.
  dup sb_allocate swap 2dup 2>r  rot fill  2r>
  ;
