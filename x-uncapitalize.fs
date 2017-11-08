\ galope/x-uncapitalize.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./x-c-store.fs
require ./xcase.fs

: xuncapitalize ( xca len -- )
  if dup xc@ xtolower swap xc! else drop then ;

  \ doc{
  \
  \ xuncapitalize ( xca len -- )
  \
  \ Convert the first character of UTF-8 character string _xca len_ to
  \ lowercase.
  \
  \ A conversion table must be defined first with `xtable[`.
  \
  \ See: `xuncapitalized`, `xcapitalize`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-08: Start.
