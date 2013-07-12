\ galope/sides.fs
\ sides

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)


false [if]  \ first version

: sides  ( ca0 len0 ca1 len2 -- ca3 len3 ca4 len4 )
  \ ca0 len0 = string searched;
  \   starts with the first substring found (ca2 len2)
  \ len2 = length of the substring searched for
  \ ca1 = old ca0, original starting address before the search
  { ca1 len2 }
  len2 - swap dup >r len2 + swap  \ left side
  ca1 r> ca1 -                    \ right side
  ;

[else]  \ second version; it's clearer

: sides  { ca1' len1' ca1 len1 len2 -- ca3 len3 ca4 len4 }
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
