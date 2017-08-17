\ galope/minus-path.fs
\ -path

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)

require ./sides-slash.fs  \ 'sides/'

: -path  ( ca len -- ca' len' )
  \ Remove the file path and leave the filename.
  \ ca len = filename with path
  \ ca' len' = filename
  s" /" sides/ if  2nip  else  2drop  then
  ;
