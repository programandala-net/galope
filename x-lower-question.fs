\ galope/x-lower-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2016, 2017.

\ ==============================================================
\ Requirements

\ From Galope
require ./x-conversions.fs

\ From Forth Foundation Library
require ffl/chr.fs \ char data type

\ ==============================================================

: xlower? ( xc -- f )
  dup xconversion? if (xlower?) else chr-lower? then ;

  \ doc{
  \
  \ xlower? ( xc -- f )
  \
  \ Is _xc_ an lowercase extended character in the conversion table
  \ defined by `xconversions`?
  \
  \ See: `xupper?`, `xtolower`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-08: Extract from <x-conversions.fs>.
