\ galope/file-mtime.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2015, 2017.

\ ==============================================================

require ./s-plus.fs

: file-mtime  ( ca1 len1 -- ca2 len2 )
  s" stat --format=%y " 2swap s+ s" > /tmp/galope.file-mtime" s+ system
  s" /tmp/galope.file-mtime" slurp-file ;

  \ doc{
  \
  \ file-mtime  ( ca1 len1 -- ca2 len2 )
  \
  \ Get modification time _ca2 len2_ (as an ISO date string) of a file
  \ _ca1 len1_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2015-01-17: Start.
\
\ 2017-07-15: Require `s+`, which was removed from Gforth 0.7.9.
\ Update layout. Improve documentation.
