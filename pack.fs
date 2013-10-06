\ galope/pack.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-08-28 Written, after iForth's 'pack'.

: pack  ( ca1 len1 ca2 -- ca2 )
  dup >r place r>
  ;
