\ galope/slash-spaces.fs
\ Left justify a string.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2017.

\ ==============================================================

require ./s-plus.fs

: /spaces  ( ca1 len1 len2 -- ca3 len2 )
  >r pad r@  2dup blank  s+ drop r> ;

  \ doc{
  \
  \ /spaces  ( ca1 len1 len2 -- ca3 len2 )
  \
  \ Left justify a string _ca1 len1_ by adding spaces to its right
  \ until its length is _len2_, returning string _ca3 len2_.  If
  \ _len1_=_len2_, _ca3 len2_ is identical to _ca1 len1_. If
  \ _len1_>_len2_, _ca1 len1_ is truncated at the right.
  \
  \
  \ See: `spaces/`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-08-16: Written.
\
\ 2014-11-16: Comments are updated.
\
\ 2017-07-15: Require `s+`, which was removed from Gforth 0.7.9.
\ Update layout. Improve documentation.
