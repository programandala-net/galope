\ galope/n-to-str-plus.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-02-17 Moved from Asalto y castigo
\ (http://programandala.net/es.programa.asalto_y_castigo.html), to be
\ reused in <galope/to-yyyymmddhhmmss.fs>.
\ 2015-10-15: Updated filenames.

require ./n-to-str.fs

: n>str+  ( ca1 len1 n -- ca2 len2 )
  \ Convert a number to a string and add it to a given string.
  n>str s+
  ;
