\ galope/n-to-str-plus.fs
\ `n>str+`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2015, 2017.

\ ==============================================================

require ./n-to-str.fs
require ./s-plus.fs

: n>str+ ( ca1 len1 n -- ca2 len2 )
  n>str s+ ;

  \ doc{
  \
  \ n>str+ ( ca1 len1 n -- ca2 len2 )
  \
  \ Convert a number _n_ to a string and add it to a given string _ca1
  \ len2_, returning the result in _ca2 len2_.
  \
  \ See: `n>str`, `s+`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-02-17: Move from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.html), to be
\ reused in <galope/to-yyyymmddhhmmss.fs>.
\
\ 2015-10-15: Update filenames.
\
\ 2017-07-15: Require `s+`, which was removed from Gforth 0.7.9.
\ Update layout. Improve documentation.
