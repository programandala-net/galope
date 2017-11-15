\ galope/compile-only-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programanda.net), 2017.

\ ==============================================================

[undefined] compile-only? [if]

\ Gforth<0.7.9

require ./name-to-flags.fs

: compile-only? ( nt -- f )
  name>flags @ restrict-mask and 0<> ;

  \ doc{
  \
  \ compile-only? ( nt -- f )
  \
  \ _f_ is true if the word _nt_ is compile-only (ie. restrict).
  \
  \ NOTE: The _nt_ of a compile-only word _name_ can not be obtained
  \ by `' _name_ >name`, because `'` performs `-14 throw` if _name_
  \ has no interpretation semantics. `comp' _name_ drop >name` can be
  \ used instead, or simply `(') _name_`.
  \
  \ See: `immediate?`, `name>flags`.
  \
  \ }doc

[then]

\ ==============================================================
\ Change log

\ Start.
