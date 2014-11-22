\ galope/sconstant.fs
\ String constant

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History

\ 2012-05-01: Extracted from and application of the author.
\ 2014-11-02: Change: Stack comments.

: sconstant  (  a len "name" -- )
  create  s,
  does>  ( -- a len ) ( pfa ) count
  ;
