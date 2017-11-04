\ galope/minus-path.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require ./sides-slash.fs  \ 'sides/'

: -path ( ca1 len1 -- ca2 len2 | ca1 len1 )
  s" /" sides/ if 2nip else 2drop then ;

  \ doc{
  \
  \ -path ( ca1 len1 -- ca2 len2 | ca1 len1 )
  \
  \ Remove the file path from character string _ca1 len1_, resulting
  \ filename _ca2 len2_, which is the part of _ca1 len1_ after its
  \ last slash ('/').  If _ca1 len1_ has no slash, return _ca1 len1_.
  \
  \ See: `-extension`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo).
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-11-04: Improve documentation.
