\ galope/sconstant.fs
\ String constant

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History

\ 2012-05-01 Extracted from and application of the author.

: sconstant  (  a1 u1 "name" -- )
  create  s,
  does>  ( pfa -- a2 u1 )  count
  ;
