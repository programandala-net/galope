\ galope/bracket-or.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

: [or] ( x1 x2 -- x3 ) or ; immediate

  \ doc{
  \
  \ [or] ( x1 x2 -- x3 )
  \
  \ _x3_ is the bit-by-bit inclusive-or of _x1_ and _x2_. ``[or]`` is
  \ an immediate word.
  \
  \ See: `[true]`, `[false]`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-08: Copied from an application by the author.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-10-25: Improve documentation.
