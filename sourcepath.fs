\ galope/sourcepath.fs
\ `sourcepath`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2016.

\ ==============================================================

require ./minus-filename.fs

: sourcepath  ( -- ca len )
  sourcefilename -filename  ;
  \ Return the path of the source file being interpreted.

\ ==============================================================
\ History

\ 2013-09-28: Start.
\
\ 2016-07-11: Update source layout and file header.
