\ galope/minus-bounds.fs
\ -bounds

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-07-11: Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)
\
\ 2014-11-09: New: Comment about '-loop' in Gforth.

: -bounds  ( ca1 len -- ca2 ca1 )
  \ Convert an address and length to the parameters needed by a
  \ "do ... -1 +loop" in order to examine that memory zone in
  \ reverse order.
  \ len = length in address units
  \ XXX Note: "do ... 1 -loop" does not work the same way in Gforth
  \ and can not be used with this '-bounds'.
  2dup + 1- nip  \ This works with '-1 +loop'
\  over 1- >r + 1- r> swap  \ This variant works with '1 -loop'
  ;
