\ galope/type-left-field.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807271752
\ See change log at the end of the file.

\ Author: Marcos Cruz (programandala.net), 2016, 2017, 2018.

\ ==============================================================

: padding-spaces ( len1 len2 -- ) swap - 0 max spaces ;

  \ doc{
  \
  \ padding-spaces ( len1 len2 -- )
  \
  \ If _len2_ minus _len1_ is a positive number, display that
  \ number of spaces; else do nothing.
  \
  \ See: `type-left-field`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-25: Adapt from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
