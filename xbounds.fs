\ galope/xbounds.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require ./to-x-width.fs

: xbounds ( xca1 len1 -- xca1 len2 0 ) >x-width 0 ;

  \ doc{
  \
  \ xbounds ( xca1 len1 -- xca1 len2 0 ) >x-width 0 ;
  \
  \ Convert the UTF-8 string _xca len_ to the parameters needed to
  \ explore it in a ``do loop`` structure.
  \
  \ Usage example:

  \ ----
  \ : output ( xca len ) xbounds do xc@+ xemit loop drop ;
  \ ----

  \ Compare it to an equivalent ASCII string loop:

  \ ----
  \ : output ( ca len -- ) bounds do i c@ emit loop ;
  \ ----

  \ }doc

\ ==============================================================
\ Change log

\ 2012-09-21 Copied from a program of the author.
\
\ 2017-08-19: Update change log layout. Update source style and stack
\ notation. Document.
\
\ 2017-11-08: Improve documentation.
