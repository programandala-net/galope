\ galope/slash-first-name.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./slash-name.fs

: /first-name ( ca1 len1 -- ca2 len2 ca3 len3 )
  /name tuck 2>r - 2r> 2swap ;

  \ doc{
  \
  \ /first-name ( ca1 len1 -- ca2 len2 ca3 len3 )
  \
  \ Get the first name _ca3 len3_ from string _ca2 len2_, returning
  \ also the remaining string _ca3 len3_.
  \
  \ See also: `first-name`, `/name`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-09-08: Copy from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
