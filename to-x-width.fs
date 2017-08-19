\ galope/to-x-width.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

: >x-width ( ca1 len1 -- ca1 len2 ) 2dup x-width nip ;

  \ doc{
  \
  \ >x-width ( ca1 len1 -- ca1 len2 )
  \
  \ Convert the byte length _len1_ of an UTF-8 string _ca1 len1_ to
  \ its character length _len2_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-09-21 Copied from a program of the author.
\
\ 2017-08-19: Update change log layout. Update source style and stack
\ notation. Document.
