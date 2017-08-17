\ galope/hunt.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Wil Baden, from Charscan library (2003-02-17), public
\ domain.

\ ==============================================================

: hunt ( ca1 len1 ca2 len2 -- ca3 len3 )
  search 0= if chars + 0 then ;
  \ Search a string ca1 len1 for a substring ca2 len2.
  \ Return the part of ca1 len1 that starts with the first
  \ occurence of ca2 len2.
  \ ca1 len1 = string
  \ ca2 len2 = substring
  \ ca3 len3 = ca1+i len1-i

\ ==============================================================
\ Change log

\ 2013-07-11: Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo.html)
\
\ 2015-08-08: Typo.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
