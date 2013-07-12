\ galope/minus-extension.fs
\ -extension

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)

require ./minus-bounds.fs  \ '-bounds'

: -extension  ( ca1 len1 -- ca1 len1' | ca1 len1 )
  \ Remove the file extension of a filename.
  2dup -bounds 1+ 2swap  \ default raw return values
  -bounds ?do
    i c@ '.' = if  drop i  leave  then
  -1 +loop  ( ca1 ca1' )  \ final raw return values
  over -
  ;
