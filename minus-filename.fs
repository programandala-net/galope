\ galope/minus-filename.fs
\ -filename

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require ./sides-slash.fs
require ./s-plus.fs

: -filename ( ca1 len1 -- ca2 len2 )
  s" /" sides/ if 2drop s" /" s+ else 2nip then ;

  \ doc{
  \
  \ -filename  ( ca len -- ca' len' )
  \
  \ Remove the filename from the string _ca1 len2_ and leave only its
  \ path _ca2 len2_ (with ending slash).
  \
  \ See: `sides/`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-11: Copy the code from Fendo
\ (http://programandala.net/en.program.fendo.html).
\
\ 2017-07-15: Require `s+`, which was removed from Gforth 0.7.9.
\ Update layout. Improve documentation.
