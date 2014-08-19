\ galope/unslurp.fs
\ This file is part of Galope

\ Copyright (C) 2013,2014 Marcos Cruz (programandala.net)

\ 2013-11-28: First version, 'unslurp, after Gforth's 'slurp-file'.
\ 2014-02-21: Renamed to 'unslurp-file'.

: unslurp-file  ( ca1 len1 ca2 len2 -- )
  \ ca1 len1 = content to write to the file
  \ ca2 len2 = filename
  w/o create-file throw >r
  r@ write-file throw
  r> close-file throw
  ;
