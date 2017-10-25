\ galope/enum.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017.

\ ==============================================================

: enum ( n "name" -- n+1 ) dup constant 1+ ;

  \ doc{
  \
  \ enum ( n1 "name" -- n2 )
  \
  \ Create a constant _name_ with value _n1_. Then get _n2_ by
  \ adding 1 to _n1_.
  \
  \ Usage example:
  \
  \ ----

  \ 0
  \ enum first
  \ enum second
  \ enum third
  \ enum fourth
  \ drop

  \ ----
  \
  \ See: `bit-enum`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-06: First version.
\
\ 2012-09-14: Code reformated.
\
\ 2016-07-11: Update source layout and file header, fix comment.
\
\ 2017-10-25: Improve documentation.
