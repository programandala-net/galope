\ galope/spaces-slash.fs
\ Right justify a string.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2017.

\ ==============================================================

require ./string-slash.fs
require ./s-plus.fs

: spaces/ ( ca1 len1 len2 -- ca3 len2 )
  >r pad r@  2dup blank  2swap s+ r> string/ ;

  \ doc{
  \
  \ spaces/ ( ca1 len1 len2 -- ca3 len2 )
  \
  \ Right justify a string _ca1 len1_ by adding spaces to its left
  \ until its length is _len2_.  If _len1_=_len2_, _ca3 len2_ is
  \ identical to _ca1 len1_.  If len1>len2, _ca1 len1_ is truncated at
  \ the left.
  \
  \ See: `/spaces`, `string/`.
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
