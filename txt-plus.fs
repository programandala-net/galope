\ galope/txt-plus.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017.

\ ==============================================================

require ./s-plus.fs
require ./either-empty-question.fs

: (txt+)  ( ca1 len1 ca2 len2 -- ca3 len3 )
  2>r s"  " s+ 2r> s+  ;

  \ doc{
  \
  \ (txt+)  ( ca1 len1 ca2 len2 -- ca3 len3 )
  \
  \ Concatenate strings _ca1 len1_ and _ca2 len2_ adding a space
  \ between them, resulting string _ca3 len3_.
  \
  \ ``(txt+)`` is a factor of `txt+`.
  \
  \ }doc

: txt+  ( ca1 len1 ca2 len2 -- ca3 len3 )
  either-empty? if s+ else (txt+) then  ;

  \ doc{
  \
  \ txt+ ( ca1 len1 ca2 len2 -- ca3 len3 )
  \
  \ Concatenate strings _ca1 len1_ and _ca2 len2_, resulting string
  \ _ca3 len3_. If neither _ca1 len1_ or _ca2 len2_ are empty, add a
  \ space between them.
  \
  \ See: `(txt+)`, `ss+`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-19: Move and adapt from <stringer.fs>.
\
\ 2016-07-22: Improve description.
\
\ 2017-08-17: Require `s+`. Document. Update header and source style.
