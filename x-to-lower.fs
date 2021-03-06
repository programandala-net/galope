\ galope/x-to-lower.fs

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

: xtolower ( xc1 -- xc1 | xc2 )
  dup xconversion? if (xtolower) else chr-lower then ;

  \ doc{
  \
  \ xtolower ( xc1 -- xc1 | xc2 )
  \
  \ Convert _xc1_ to lowercase, returning _xc2_ or _xc1_, after the
  \ conversion table defined with `xconversions`.
  \
  \ See: `xtoupper`, `xlower?`, `xuncapitalized`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-08: Extract from <x-conversions.fs>.
