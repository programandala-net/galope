\ galope/tick-last-char.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

: 'last-char ( ca1 len1 -- ca2 ) + [ 1 chars ] - ;

  \ doc{
  \
  \ 'last-char ( ca1 len1 -- ca2 )
  \
  \ Return the address _ca2_ of the last character of an ASCII string
  \ _ca1 len1_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-12-18: Added. Code copied from an application of the author.
\
\ 2015-10-13: Renamed; `chars`.
\
\ 2017-08-19: Update change log layout. Update source style and stack
\ notation. Document.
