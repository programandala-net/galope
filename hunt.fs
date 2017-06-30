\ galope/hunt.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History.
\ 2013-07-11: Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo.html)
\ 2015-08-08: Typo.

: hunt  ( ca1 len1 ca2 len2 -- ca3 len3 )
  \ Search a string ca1 len1 for a substring ca2 len2.
  \ Return the part of ca1 len1 that starts with the first
  \ occurence of ca2 len2.
  \ From Wil Baden's Charscan library (2003-02-17), public domain.
  \ ca1 len1 = string
  \ ca2 len2 = substring
  \ ca3 len3 = ca1+i len1-i
  search 0= if  chars + 0  then
  ;
