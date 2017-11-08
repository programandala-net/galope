\ galope/x-upper-question.fs

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

: xupper? ( xc -- f )
  dup xconversion? if (xupper?) else chr-upper? then ;

  \ doc{
  \
  \ xupper? ( xc -- f )
  \
  \ Is _xc_ an uppercase extended character in the conversion table
  \ defined by `xconversions`?
  \
  \ See: `xlower?`, `xtoupper`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-08: Extract from <x-conversions.fs>.
