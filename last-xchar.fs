\ galope/last-xchar.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017, 2018.

\ ==============================================================

require tick-last-xchar.fs  \ "'last_xchar"

: last-xchar ( ca len -- xc ) 'last-xchar xc@ ;

  \ doc{
  \
  \ last-xchar ( xca len -- xc )
  \
  \ Return the last xchar _xc_ of string _xca len_.
  \
  \ See: `'last-xchar`, `xbounds`, `xchar-count`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-12-18 Added. Code copied from an application of the author.
\
\ 2015-10-13: Renamed.
\
\ 2017-08-19: Update change log layout. Update source style and stack
\ notation. Document.
\
\ 2018-07-24: Improve documentation.
