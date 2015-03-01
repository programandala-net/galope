\ galope/file-mtime.fs

\ This file is part of Galope

\ Copyright (C) 2015 Marcos Cruz (programandala.net)

\ 2015-01-17

: file-mtime  ( ca1 len1 -- ca2 len2 )
  \ Modification time of a file
  \ ca1 len1 = filename
  \ ca2 len2 = modification time, as an ISO date string
  s" stat --format=%y " 2swap s+ s" > /tmp/galope.file-mtime" s+ system
  s" /tmp/galope.file-mtime" slurp-file
  ;
