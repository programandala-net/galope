\ galope/minus-suffix.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require ./string-suffix-question.fs

: -suffix ( ca1 len1 ca2 len2 -- ca1 len1 | ca3 len3 )
  dup >r 2over 2swap string-suffix?
  if r> - else rdrop then ;

  \ doc{
  \
  \ -suffix ( ca1 len1 ca2 len2 -- ca1 len1 | ca3 len3 )
  \
  \ Remove a suffix _ca2 len2_ from a character string _ca1 len1_,
  \ resulting character string _ca3 len3_. If _ca2 len2_ is not a
  \ suffix of _ca1 len1_, return _ca1 len1_.
  \
  \ See: `-prefix`, `-extension`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-05-18: Added.
\
\ 2015-08-07: Updated the stack notation.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-11-04: Improve documentation.
