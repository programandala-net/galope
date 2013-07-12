\ galope/minus-bounds.fs
\ -bounds

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)

: -bounds  ( ca1 len1 -- ca2 ca1 )
  \ Convert an address and length to the parameters needed by a
  \ "do ... +loop" in order to examine that memory zone in
  \ reverse order.
  2dup + 1- nip 
  ;
