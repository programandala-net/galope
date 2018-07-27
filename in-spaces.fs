\ galope/in-spaces.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018

\ ==============================================================

: in-spaces ( ca1 len1 -- ca2 len2 ) s"  " 2swap s"  " s+ s+ ;

  \ doc{
  \
  \ in-spaces ( ca1 len1 -- ca2 len2 )
  \
  \ Return string _ca1 len1_ in spaces (i.e. surrounded by one
  \ space at each end) as string _ca2 len2_.
  \
  \ See: `in-parens`, `in-brackets`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-27: Written.
