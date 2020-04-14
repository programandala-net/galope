\ galope/s-s-plus.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017, 2018, 2020.

\ ==============================================================

require ./stringer.fs
require ./both-lengths.fs
require ./smove.fs

: ss+ ( ca1 len1 ca2 len2 -- ca3 len3 )
  both-lengths + >r           ( ca1 len1 ca2 len2 ) ( R: len3 )
  r@ allocate-in-stringer >r  ( R: len3 ca3 )
  2 pick r@ +                 ( ca1 len1 ca2 len2 ca3+len1 )
  smove                       ( ca1 len1 )
  r@ smove r> r> ;

  \ doc{
  \
  \ ss+ ( ca1 len1 ca2 len2 -- ca3 len3 )
  \
  \ Concatenate strings _ca1 len1_ and _ca2 len2_, returning the
  \ result _ca3 len3_ in the `stringer`.
  \
  \ This is an alternative to Gforth's ``s+``, which allocates the
  \ result in the common heap.
  \
  \ See: `txt+`, `ss"`, `>stringer`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-19: Move from <stringer.fs>.
\
\ 2016-07-20: Improve comment.
\
\ 2016-07-22: Improve comment.
\
\ 2017-08-17: Document. Update header and source style.
\
\ 2018-07-21: Update `allocate-ss` to `allocate-in-stringer`. Improve
\ documentation.
\
\ 2020-01-19: Improve documentation.
\
\ 2020-04-14: Improve documentation.
