\ galope/hunt.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Wil Baden, from Charscan library (2003-02-17), public domain

\ ==============================================================

: hunt ( ca1 len1 ca2 len2 -- ca3 len3 )
  search 0= if chars + 0 then ;

  \ doc{
  \
  \ hunt ( ca1 len1 ca2 len2 -- ca3 len3 )
  \
  \ Search a string _ca1 len1_ for a substring _ca2 len2_.  Return
  \ _ca3 len3_, which is the part of _ca1 len1_ that starts with the
  \ first occurence of _ca2 len2_.  Therefore _ca3 len3 = ca1+i
  \ len1-i_.
  \
  \ See: `contains?`, `instr`, `instr?`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-11: Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo.html).
\
\ 2015-08-08: Typo.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-10-25: Improve documentation.
