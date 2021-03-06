\ galope/replaced.fs
\ `replaced`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2016, 2017, 2018.

\ ==============================================================

require ./package.fs
include ffl/str.fs

package galope-replaced

str-create tmp-str

public

: replaced ( ca1 len1 ca2 len2 ca3 len3 -- ca1' len1' )
  2rot tmp-str str-set  tmp-str str-replace  tmp-str str-get  ;

  \ doc{
  \
  \ replaced ( ca1 len1 ca2 len2 ca3 len3 -- ca1' len1' )
  \
  \ Replace all ocurrences of _ca3 len3_ ("needle") in _ca1 len1_
  \ ("haystack") with _ca2 len2_.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2014-02-28: Copy from Fendo
\ (http://programandala.net/en.program.fendo.html); change the order
\ of the parameters.
\
\ 2016-06-28: Update file header, source style and comment.
\
\ 2016-07-11: Update source layout and file header.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2018-05-07: Improve documentation.
\
\ 2018-09-27: Replace `require` with `include` to load <ffl/str.fs>.
\ This solves a strange problem with Gforth's `require` (see its
\ `.included`).
