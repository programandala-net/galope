\ galope/minus-extension.fs
\ -extension

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-07-11: Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo.html)
\
\ 2017-02-27: Update code style.

require ./minus-bounds.fs  \ '-bounds'

: -extension ( ca1 len1 -- ca1 len1' | ca1 len1 )
  2dup -bounds 1+ 2swap \ default raw return values
  -bounds ?do
    i c@ '.' = if drop i leave then
  -1 +loop ( ca1 ca1' ) \ final raw return values
  over - ;
  \ Remove the file extension from a filename.
