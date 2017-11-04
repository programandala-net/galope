\ galope/minus-extension.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require ./minus-bounds.fs  \ '-bounds'

: -extension ( ca1 len1 -- ca1 len1' | ca1 len1 )
  2dup -bounds 1+ 2swap \ default raw return values
  -bounds ?do
    i c@ '.' = if drop i leave then
  -1 +loop ( ca1 ca1' ) \ final raw return values
  over - ;

  \ doc{
  \
  \ -extension ( ca1 len1 -- ca1 len2 | ca1 len1 )
  \
  \ Remove the file extension from the filename identified by the
  \ character string _ca1 len1_.  The file extension is the substring
  \ that start at the last '.' of the string.
  \
  \ See: `-suffix`, `-bounds`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-11: Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo.html)
\
\ 2017-02-27: Update code style.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-11-04: Improve documentation.
