\ galope/semicolon-strings.fs
\ `;strings`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2016.

\ ==============================================================

: ;strings  ( i*x -- )  /strings drop  ;
  \ End the definition of a constant string array.  This in an
  \ optional ending for the string arrays provided by
  \ <galope/constant_string_arrays_1.fs>  and
  \ <galope/constant_string_arrays_2.fs>.

\ ==============================================================
\ History

\ 2013-11-30: Start.
\
\ 2016-08-02: Update source layout and file header. Fix stack comment.
