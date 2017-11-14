\ galope/c-to-str.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

0 [if]  \ old
require ./buffer-colon.fs
2 chars buffer: (c>str)
: c>str  ( c -- ca len )
  (c>str) c! (c>str) 1  ;
  \ Convert an ASCII char to a string.
[then]

: c>str ( c -- ca len ) 1 allocate throw tuck c! 1 ;

  \ doc{
  \
  \ c>str ( c -- ca len )
  \
  \ Convert a single-byte character _c_ to a string _ca len_
  \ in data space allocated by ``allocate``. _ca_ is the aligned
  \ address where _c_ is stored, and _len_ is 1.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-06-10 Added.
\
\ 2013-11-26 Alias 'c>str'.
\
\ 2013-12-29 Ad hoc buffer instead of 'pad'; word and alias names
\ exchanged.
\
\ 2014-01-01 Fix: One single buffer made it impossible to use this
\ word several times in the same code, because every string overwrited
\ the previous one! Allocated memory is used instead, as Gforth strings do.
\
\ 2015-10-15: Renamed the file.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-10-25: Improve documentation.
\
\ 2017-11-14: Remove deprecated alias `c>s`.
