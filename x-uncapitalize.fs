\ galope/x-uncapitalize.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./x-c-store.fs
require ./x-to-lower.fs

: xuncapitalize ( xca len -- )
  if dup xc@ xtolower swap xc! else drop then ;

  \ doc{
  \
  \ xuncapitalize ( xca len -- )
  \
  \ Convert the first character of the UTF-8 character string _xca
  \ len_ to lowercase.
  \
  \ A conversion table must be defined first with `xconversions`.
  \
  \ See: `xuncapitalized`, `xlowercase`, `xtolower`, `xcapitalize`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-08: Start.
\
\ 2017-11-10: Improve documentation.
