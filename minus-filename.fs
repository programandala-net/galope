\ galope/minus-filename.fs
\ -filename

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)

require ./sides-slash.fs  \ 'sides/'

: -filename  ( ca len -- ca' len' )
  \ Remove the filename and leave the path (with ending slash).
  \ ca len = filename with path
  \ ca' len' = path (with ending slash)
  s" /" sides/ if  2drop s" /" s+  else  2nip  then
  ;
