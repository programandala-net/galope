\ galope/minus-prefix.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2018.

\ ==============================================================

require ./gforth-question.fs

gforth? 0= [if]
  : string-prefix? ( ca1 len1 ca2 len2 -- f )
    tuck 2>r min 2r> str= ;
[then]

false [if] \ XXX OLD -- first version

: -prefix ( ca1 len1 ca2 len2 -- ca3 len3 | ca1 len1 )
  dup >r 2over 2swap string-prefix?
  if swap r@ + swap r> - else rdrop then ;

[then]

: -prefix ( ca1 len1 ca2 len2 -- ca1' len1' )
  dup >r 2over 2swap string-prefix? r> and /string ;

  \ doc{
  \
  \ -prefix ( ca1 len1 ca2 len2 -- ca3 len3 | ca1 len1 )
  \
  \ Remove a prefix _ca2 len2_ from a character string _ca1 len1_,
  \ resulting character string _ca3 len3_.  If _ca2 len2_ is not a
  \ prefix of _ca1 len1_, return _ca1 len1_.
  \
  \ See: `-suffix`, `-leading`, `-common-prefix`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-05-18: Added. First version.
\
\ 2015-12-16: Second, simpler version.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-11-04: Improve stack comments. Improve documentation.
\
\ 2018-09-27: Update documentation.
