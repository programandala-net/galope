\ galope/both-lengths.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016, 2017.

\ ==============================================================

: both-lengths ( ca1 len1 ca2 len2 -- ca1 len1 ca2 len2 len1 len2 )
  2 pick over ;

  \ doc{
  \
  \ both-lengths ( ca1 len1 ca2 len2 -- ca1 len1 ca2 len2 len1 len2 )
  \
  \ Copy the lenghts of strings _ca1 len1_ and _ca2 len2_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-19: Extract `lengths` from the <sb.fs> module and rename it.
\
\ 2017-08-17: Update change log layout. Update source style.
\
\ 2017-10-25: Improve documentation.
