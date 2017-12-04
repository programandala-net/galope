\ galope/name-to-flags.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programanda.net), 2017.

\ ==============================================================

: name>flags ( nt -- a )
  [ s" gforth" environment? drop s" 0.7.9" str< ]
  [if] cell+ [else] >f+c [then] ;

  \ doc{
  \
  \ name>flags ( nt -- a|ca )
  \
  \ Convert _nt_ to the address of the flags byte _ca_.
  \
  \ See: `immediate?`, `compile-only?`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-15: Start.
