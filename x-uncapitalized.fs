\ galope/x-uncapitalized.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./x-uncapitalize.fs \ `xuncapitalize`

: xuncapitalized ( xca1 len -- xca2 len )
  save-mem 2dup xuncapitalize ;

  \ doc{
  \
  \ xuncapitalized ( xca1 len -- xca2 len )
  \
  \ Copy the UTF-8 character string _xca1 len_ to the heap and return
  \ it as _xca2 len_ with its first character converted to lowercase.
  \
  \ A conversion table must be defined first with `xconversions`.
  \
  \ See: `xuncapitalize`, `xlowercase`, `xtolower`, `xcapitalized`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-08: Start.
\
\ 2017-11-10: Improve documentation.
