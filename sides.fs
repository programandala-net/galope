\ galope/sides.fs
\ sides

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)
\ 2013-11-06 New: a comment to explain what the word does.


false [if]  \ first version

: sides  ( ca0 len0 ca1 len2 -- ca3 len3 ca4 len4 )
  \ Convert the result returned by 'search': divide the searched
  \ string at the substring that was searched to.
  \ ca0 len0 = string searched;
  \   starts with the first substring found (ca2 len2)
  \ len2 = length of the substring searched for
  \ ca1 = old ca0, original starting address before the search
  { ca1 len2 }
  len2 - swap dup >r len2 + swap  \ left side
  ca1 r> ca1 -                    \ right side
  ;

[else]  \ second version; clearer

: sides  { ca1' len1' ca1 len1 len2 -- ca3 len3 ca4 len4 }
  \ Convert the result returned by 'search': divide the searched
  \ string at the substring that was searched to.
  \ ca1' len1' = string searched, starting with the first (ca2 len2)
  \ ca1 len1 = original string, before the search
  \ len2 = length of the substring searched for
  \ ca1' len2 = substring found in ca1 len1
  \ ca3 len3 = left side of ca1 len1, until and excluding ca1' len2
  \ ca4 len4 = right side of ca1 len1, after ca1' len2
  ca1  len1 len1' -          \ left side
  ca1' len2 +  len1' len2 -  \ right side
  ;

[then]
