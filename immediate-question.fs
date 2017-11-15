\ galope/immediate-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programanda.net), 2017.

\ ==============================================================

[undefined] immediate? [if]

\ Gforth<0.7.9

require ./name-to-flags.fs

: immediate? ( nt -- f )
  name>flags @ immediate-mask and 0<> ;

  \ doc{
  \
  \ immediate? ( nt -- f )
  \
  \ _f_ is true if the word _nt_ is immediate.
  \
  \ NOTE: ``immediate?`` is included in Gforth 0.7.9. If
  \ ``immediate?`` is defined already, this module does nothing.
  \
  \ See: `compile-only?`, `name>flags`.
  \
  \ }doc

[then]

\ ==============================================================
\ Change log

\ Start.
