\ galope/txt-plus.fs
\ `txt+`
\ Concatenation of text strings.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ Description: An operator to concatenate text strings, therefore
\ using a space separator when needed. The actual concatenation is
\ done with `s+`, provided by Gforth; but it may be previously
\ redefined as an alias of `ss+` (module <s-s-plus.fs>), which uses
\ the stringer (a circular string buffer, module <stringer.fs>).

\ ==============================================================

require ./either-empty-question.fs

: (txt+)  ( ca1 len1 ca2 len2 -- ca3 len3 )
  2>r s"  " s+ 2r> s+  ;
  \ Concatenate two text strings with a space.

: txt+  ( ca1 len1 ca2 len2 -- ca3 len3 )
  either-empty? if  s+  else  (txt+)  then  ;
  \ Concatenate two text strings with a space, if needed.

\ ==============================================================
\ History

\ 2016-07-19: Move and adapt from <stringer.fs>.
\ 2016-07-22: Improve description.
