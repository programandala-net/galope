\ galope/tick-last-xchar.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require ./xbounds.fs

: 'last-xchar ( ca1 len1 -- ca2 )
  xbounds swap 1- swap ?do xchar+ loop ;

  \ doc{
  \
  \ 'last-xchar ( ca1 len1 -- ca2 )
  \
  \ Return the address _ca2_ of the last xchar of a UTF-8 string _ca1
  \ len1_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-12-18: Added. Code copied from an application of the author.
\
\ 2013-07-07: Fix: 'do' changed to '?do'; it failed with one-character
\ strings.
\
\ 2015-10-13: Renamed.
\
\ 2017-08-19: Update change log layout. Update source style and stack
\ notation. Document.
