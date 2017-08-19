\ galope/last-xchar.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require tick-last-xchar.fs  \ "'last_xchar"

: last-xchar ( ca len -- xc ) 'last-xchar xc@ ;

  \ doc{
  \
  \ last-xchar ( ca len -- xc )
  \
  \ Return the last xchar _xc_ of a UTF-8 string _ca len_.
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
