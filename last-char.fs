\ galope/last-char.fs
\ 'last-char'

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ ==============================================================

require tick-last-char.fs  \ "'last_char"

: last-char  ( ca len -- c ) 'last-char c@ ;
  \ Return the last char of an ASCII string.

\ ==============================================================
\ Change log

\ 2012-12-18: Added. Code copied from an application of the author.
\
\ 2015-10-13: Renamed.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style and stack notation.
